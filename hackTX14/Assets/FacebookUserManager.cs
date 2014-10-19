using UnityEngine;
using System.Collections;

public class FacebookUserManager : MonoBehaviour {
	public TextAsset textAsset;
	FacebookUser facebookUser;
	// Use this for initialization
	void Start () {
		facebookUser = new FacebookUser (textAsset.text);
		GameObject.Find("FB_Name").GetComponent<TextMesh>().text = (facebookUser.first_name+" "+facebookUser.last_name);
		GameObject.Find("FB_Bio").GetComponent<TextMesh>().text = (facebookUser.bio);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
