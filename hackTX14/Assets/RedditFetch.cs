using UnityEngine;
using System.Collections;
using SimpleJSON;

public class RedditFetch : MonoBehaviour {

	private string[] _items = new string[0];
	private Vector2 _scrollPosition;


	IEnumerator Start () {
		WWW www = new WWW("http://reddit.com/.json");
		yield return www;
		
		var json = JSON.Parse(www.text);
		
		var arr = json["data"]["children"].AsArray;

		_items = new string[arr.Count];
		for(int i = 0; i < arr.Count; i++) {
			_items[i] = arr[i]["data"]["title"];
		}
	}

	void Update () {
	
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, 200, 400));
		GUILayout.BeginScrollView(_scrollPosition);
		GUILayout.BeginVertical();

		for(int i = 0; i < _items.Length; i++) {
			GUILayout.Label(_items[i]);
		}

		if(GUILayout.Button("TEST")) {
			Debug.Log("TEST");
		}

		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}
}
