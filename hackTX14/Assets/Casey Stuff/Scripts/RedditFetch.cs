using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleJSON;

public class RedditFetch : MonoBehaviour {
	
	public GameObject PostPrefab;
	public TextMesh Label;
	public string SubredditFeed;

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
		Label.text = "/r/" + SubredditFeed;
		string rURL = string.Format("http://reddit.com/r/{0}/.json", SubredditFeed.ToLower());
		WWW www = new WWW(rURL);
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
		int count = _postRoot.transform.childCount;
		_postX = (count % 3) * 2;

		if(count % 3 == 0) {
			_postY++;
		}

		post.transform.position = new Vector3(11, 6 + _postY * -2, -2 + _postX);

		RedditPicturePost rpp = post.GetComponent<RedditPicturePost>();
		rpp.FindReferences();
		rpp.ImageMat.mainTexture = www.texture;
		rpp.Text.text = "";//title;
		post.transform.parent = _postRoot.transform;
	}

	bool StringPointsToImage(string urlString) {
		urlString = urlString.Replace(@"\", "");

		return Regex.IsMatch(urlString, @"(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|png))(?:\?([^#]*))?(?:#(.*))?");
	}
}
