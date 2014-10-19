using UnityEngine;
using System.Collections;

public class FacebookUserManager : MonoBehaviour {
	public TextAsset textAsset;
	FacebookUser facebookUser;
	// Use this for initialization
	void Start () {
		facebookUser = new FacebookUser (textAsset.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
