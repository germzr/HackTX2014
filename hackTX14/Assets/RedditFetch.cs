using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleJSON;

public class RedditFetch : MonoBehaviour {

	public GameObject PostPrefab;

	private GameObject _postRoot;
	private int _postX;
	private int _postY;

	void Start () {
		StartCoroutine(FetchListingData());

		_postRoot = new GameObject("Post Root");
		_postRoot.transform.parent = transform;
	}

	void Update () {
	
	}

	IEnumerator FetchListingData() {
		WWW www = new WWW("http://reddit.com/r/pics/.json");
		yield return www;
		
		var json = JSON.Parse(www.text);
		
		var arr = json["data"]["children"].AsArray;

		for(int i = 0; i < arr.Count; i++) {
			string url = arr[i]["data"]["url"];

			if(StringPointsToImage(url)) {
				StartCoroutine(FetchImageData(arr[i]["data"]["title"], url));
			}
		}
	}

	IEnumerator FetchImageData(string title, string url) {
		WWW www = new WWW(url);
		yield return www;
		
		GameObject post = GameObject.Instantiate(PostPrefab) as GameObject;
		post.transform.parent = _postRoot.transform;
		int count = _postRoot.transform.childCount;
		_postX = (count % 3) * 4;

		if(count % 3 == 0) {
			_postY++;
		}

		Debug.Log(_postY);
		post.transform.position = new Vector3(_postX, _postY * -4, 0);

		RedditPicturePost rpp = post.GetComponent<RedditPicturePost>();
		rpp.FindReferences();
		rpp.ImageMat.mainTexture = www.texture;
		rpp.Text.text = title;
	}

	bool StringPointsToImage(string urlString) {
		urlString = urlString.Replace(@"\", "");

		return Regex.IsMatch(urlString, @"(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|png))(?:\?([^#]*))?(?:#(.*))?");
	}
}
