using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Post {
	public string message;
	public string picture;
	public string description;


	public Post(string m, string p, string d)
	{
		message = m;
		picture = p;
		description = d;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
