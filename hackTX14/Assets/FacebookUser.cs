using UnityEngine;
using System.Collections;
using SimpleJSON;

public class FacebookUser {
	string first_name;
	string last_name;
	string picture;
	string bio;
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
