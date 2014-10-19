using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Text.RegularExpressions;

[RequireComponent(typeof(AudioSource))]
public class ContextIO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(FetchEmailData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ReadMessage(string[] args) {
		if(args[0] == "first") {
			StartCoroutine(ReadString(transform.FindChild("Email1").GetComponent<StringHolder>().TextHold));
		} else if(args[0] == "second") {
			StartCoroutine(ReadString(transform.FindChild("Email2").GetComponent<StringHolder>().TextHold));
		} else if(args[0] == "third") {
			StartCoroutine(ReadString(transform.FindChild("Email3").GetComponent<StringHolder>().TextHold));
		} else {
			StartCoroutine(ReadString("I don't understand you. Sorry."));
		}
	}

	IEnumerator FetchEmailData() {
		string rURL = "http://redpandadev.com/emailStuff/queryThisFile.php";
		WWW www = new WWW(rURL);
		yield return www;
		
		var json = JSON.Parse(www.text);
		for(int i = 0; i < json.Count; i++) {
			Transform child = transform.FindChild("Email" + (i+1));
			Debug.Log("Email" + (i+1) + child);
			Transform date = child.FindChild("Cal_Date");
			Transform desc = child.FindChild("Cal_Description");
			Transform name = child.FindChild("Cal_Name");

			date.GetComponent<TextMesh>().text = json[i]["date_received"];
			desc.GetComponent<TextMesh>().text = MakeEllipses(json[i]["subject"], 25);
			name.GetComponent<TextMesh>().text = RemoveEscapes(json[i]["addresses"]["from"]["name"]);
			string email = EmailRestructure(RemoveEscapes(json[i]["addresses"]["from"]["name"]), json[i]["date_received"], json[i]["subject"]);
			child.GetComponent<StringHolder>().TextHold = email;
		}


		ReadMessage(new string[]{"first"});
	}

	IEnumerator ReadString(string emailText) {
		Regex rgx = new Regex("\\s+");
		string result = rgx.Replace(emailText, "%20");
		string url = "http://translate.google.com/translate_tts?tl=en&q=" + result;
		WWW www = new WWW(url);
		yield return www;
		audio.clip = www.GetAudioClip(false, false, AudioType.MPEG);
		audio.Play();
	}

	string RemoveEscapes(string str) {
		str = str.Replace(@"\", "");
		return str;
	}

	string EmailRestructure(string from, string received, string subject) {
		string email = string.Format("From: {0} on {1}. Subject: {2}", from, received, subject);
		return email;
	}

	string MakeEllipses(string str, int limit){
		if(str.Length >= limit) {
			str = str.Substring(0, limit - 3);
			str = str + "...";
		}

		return str;
	}
}
