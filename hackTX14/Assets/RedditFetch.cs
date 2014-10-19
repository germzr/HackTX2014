using UnityEngine;
using System.Collections;
using SimpleJSON;

public class RedditFetch : MonoBehaviour {

	private string[] _items = new string[0];
	private Vector2 _scrollPosition;

	void Start () {
		StartCoroutine(Fetch());
	}

	void Update () {
	
	}

	IEnumerator Fetch() {
		WWW www = new WWW("http://reddit.com/.json");
		yield return www;
		
		var json = JSON.Parse(www.text);
		
		var arr = json["data"]["children"].AsArray;
		
		_items = new string[arr.Count];
		for(int i = 0; i < arr.Count; i++) {
			_items[i] = arr[i]["data"]["title"];
			Debug.Log(_items[i]);
		}
	}
}
