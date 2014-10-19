using UnityEngine;
using System.Collections;

public class FeedManager : MonoBehaviour {
	Post post;
	public TextAsset textAsset;
	// Use this for initialization
	void Start () {
		post = new Post (textAsset.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
