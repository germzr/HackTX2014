using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public static string tests="";
	void OnGUI () 
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if(GUI.Button(new Rect(Screen.width/2,200,200,150),"SpeechToText"))
			{
			SpeechToText.StartSpeech();

			}
			tests=SpeechToText.SpeechResult();
			GUI.Label(new Rect(Screen.width/2,590,200,200),tests);

			if(GUI.Button(new Rect(Screen.width/2,400,200,150),"Toast Message"))
			{
			SpeechToText.MakeToast("Logging in.....Please Wait for a moment");			
			}
		}else
			{



		GUI.Label(new Rect(Screen.width/2,Screen.height/2,300,200),"Please Build and Run in Android and see documentation for usage of functionalities.");
			}
	}

}
