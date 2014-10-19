using UnityEngine;
using System.Collections;

public class CalendarManager : MonoBehaviour {
	public Calendar calendar;
	public string calendarID;
	public TextAsset textAsset;

	// Use this for initialization
	void Start () {
		calendar = new Calendar (calendarID, textAsset.text);

		/*
		foreach (CalendarEvent calendarEvent in calendar.calendarEvents) {
			Debug.Log(calendarEvent.title + " " + calendarEvent.description + " " + calendarEvent.startingDate);		
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
