using UnityEngine;
using System.Collections;

public class Feed {

	private Post[] posts;

	public Feed(Post[] p)
	{
		posts = p;
	}

	public Post[] getFeed()
	{
		return posts;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//get updated feed
		//post = the updated info...
	}
}
