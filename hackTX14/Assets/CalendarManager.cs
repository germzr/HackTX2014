using UnityEngine;
using System.Collections;

public class CalendarManager : MonoBehaviour {
	public Calendar calendar;
	public string calendarID;
	public TextAsset textAsset;

	// Use this for initialization
	void Start () {
		calendar = new Calendar (calendarID, textAsset.text);

		//foreach(
	}

	// Update is called once per frame
	void Update () {
	
	}
}
