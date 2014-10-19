using UnityEngine;
using System.Collections;
using SimpleJSON;

public class FacebookUser {
	public string first_name;
	public string last_name;
	public string picture;
	public string bio;
	public FacebookUser(string s)
	{
		var json = JSON.Parse(s);
		first_name = json ["first_name"];
		last_name = json ["last_name"];
		picture = json ["picture"];
		bio = json ["bio"];

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
