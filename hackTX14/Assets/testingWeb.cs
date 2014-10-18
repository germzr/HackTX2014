using UnityEngine;
using System.Collections;

public class testingWeb : MonoBehaviour {

	// Use this for initialization
	public string url = "http://i.imgur.com/qXxfAQJ.jpg";
	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		renderer.material.mainTexture = www.texture;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
