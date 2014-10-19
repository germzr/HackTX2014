using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Calendar {
	public string calendarID;
	public CalendarEvent[] calendarEvents;

	public Calendar(string calID, string s) {
		calendarID = calID;


		var json = JSON.Parse (s);
		var arr = json.AsArray;

		calendarEvents = new CalendarEvent[arr.Count];

		for (int i = 0; i < arr.Count; i++) {
			calendarEvents[i] = new CalendarEvent(arr[i]["title"], arr[i]["description"], arr[i]["starting_date"]);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
