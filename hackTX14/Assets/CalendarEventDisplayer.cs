using UnityEngine;
using System.Collections;
using SimpleJSON;
public class CalendarEventDisplayer : MonoBehaviour {
	public GameObject calendarEvent;
	private TextAsset feed;
	// Use this for initialization
	void Start () {
		GameObject calendarManager = GameObject.Find ("CalendarManager");
		CalendarManager c = calendarManager.GetComponent<CalendarManager> ();


		// spawn 3 event tiles
		Vector3 startingPosition = new Vector3 (3, 3, 3);
		Vector3 position = startingPosition;
		for (int i = 0; i < 3; i++) {
			GameObject ce = (GameObject)Instantiate (calendarEvent, position, Quaternion.identity);
			position += new Vector3 (0,-calendarEvent.transform.lossyScale.y,0);
			Component[] components = ce.GetComponentsInChildren<TextMesh>();

			for(int j = 0; j < 3 ; j++) {
				TextMesh tm = (TextMesh) components[j];
				//tm.text = c.calendar.calendarEvents[j].title;
				if(tm.tag == "eventName"){
					tm.text = "name";
					tm.text = c.calendar.calendarEvents[i].title;
				}else if(tm.tag == "eventDesc"){
					tm.text = "desc";
					tm.text = c.calendar.calendarEvents[i].description;
				}else{
					tm.text = "date";
					tm.text = c.calendar.calendarEvents[i].startingDate;
				}
			}


			/*
			TextMesh tm = (TextMesh) components[i];
	
			if(tm.tag == "eventName"){
				tm.text = "name";
				tm.text = c.calendar.calendarEvents[i].title;
			}else if(tm.tag == "evenDesc"){
				tm.text = "desc";
				tm.text = c.calendar.calendarEvents[i].description;
			}else{
				tm.text = "date";
				tm.text = c.calendar.calendarEvents[i].startingDate;
			}*/
			
			/*
			for(int j = 0; j < 3 ; j++) {
				TextMesh tm = (TextMesh) components[j];
				//tm.text = c.calendar.calendarEvents[j];
				if(tm.tag == "eventName"){
					tm.text = "name";
					tm.text = c.calendar.calendarEvents[j].title;
				}else if(tm.tag == "evenDesc"){
					tm.text = "desc";
					tm.text = c.calendar.calendarEvents[j].description;
				}else{
					tm.text = "date";
					tm.text = c.calendar.calendarEvents[j].startingDate;
				}
			}*/
			/*
			foreach(Component c in components)
			{
				TextMesh t = (TextMesh) c;
				t.text = "yes";
			}*/

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
