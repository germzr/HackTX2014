using UnityEngine;
using System.Collections;

public class CalendarEventDisplayer : MonoBehaviour {

	public GameObject tile;

	// Use this for initialization
	void Start () {
		var tileChild = Instantiate(tile) as GameObject;
		tileChild.transform.position = new Vector3 (0, 3, 3);
		tileChild.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
