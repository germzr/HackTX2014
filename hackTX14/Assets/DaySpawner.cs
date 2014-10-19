using UnityEngine;
using System.Collections;

public class DaySpawner : MonoBehaviour {

	public GameObject dayObject;
	// Use this for initialization
	void Start () {
		Vector3 startingPosition = new Vector3 (3f, 0f, 3f); //starting position
		Vector3 position = startingPosition;

		//hardcoded to october...

		int numDaysToShift = 3;
		for (int i = 0; i < 3; i++) {
			spawnDay("", position);
			position += new Vector3(1f,0f,0f);
		}

		for (int i = 1; i < 32; i++) {
			spawnDay(i.ToString(), position);
			position += new Vector3(1f,0f,0f);

			if((i + numDaysToShift) % 7 == 0)
			{
				position = new Vector3(startingPosition.x,position.y,position.z);
				position += new Vector3(0f,-1f,0f);
			}
		}

		for (int i = 0; i < 1; i++) {
			spawnDay("", position);
			position += new Vector3(1f,0f,0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnDay(string dayNum, Vector3 position) {
		GameObject day = (GameObject)Instantiate (dayObject, position, Quaternion.identity);
		day.GetComponentInChildren<TextMesh> ().text = dayNum;
	}
}
