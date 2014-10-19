using UnityEngine;
using System.Collections;
using SimpleJSON;

public class CalendarEvent  {
	public string title;
	public string description;
	public string startingDate;

	public CalendarEvent(string t, string d, string sd) {
		title = t;
		description = d;
		startingDate = sd;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
