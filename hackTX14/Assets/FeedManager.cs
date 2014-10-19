using UnityEngine;
using System.Collections;
using SimpleJSON;

public class FeedManager : MonoBehaviour {
	Post[] posts;
	public TextAsset textAsset;
	public Feed feed;
	// Use this for initialization
	void Start () {
		var json = JSON.Parse (textAsset.text);
		var arr = json.AsArray;
		posts = new Post[arr.Count];

		for (int i = 0; i < arr.Count; i++) {
			posts[i] = new Post(arr[i]["message"],arr[i]["picture"],arr[i]["description"]);
		}
	
		feed = new Feed (posts);

		/*GERMAN, If you want all the stuff in the feed do this*/
		/*
		foreach (Post p in feed.getFeed()) {
			Debug.Log(p.message + " " + p.picture + " " + p.description);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
