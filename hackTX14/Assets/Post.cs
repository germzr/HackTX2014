using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Post {
	private string message;
	private string[] link;
	private string description;


	Post(string s)
	{
		var json = JSON.Parse(s);


		/*
		
		var arr = json["data"]["children"].AsArray;
		
		_items = new string[arr.Count];
		for(int i = 0; i < arr.Count; i++) {
			_items[i] = arr[i]["data"]["title"];
		}*/
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
