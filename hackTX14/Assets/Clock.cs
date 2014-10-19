using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh> ().text = string.Format("{0:hh:mm:ss tt}", DateTime.Now);

	}

}
