using UnityEngine;
using System.Collections;

public class SpeechToText : MonoBehaviour {

	private static AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	private static AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
	public static string result="Empty";
	public static void StartSpeech()
	{
		jo.Call("Launch");
	}
	public static string SpeechResult()
	{
		result=jo.CallStatic<string>("ReturnString");
		return result;
	}
	public static void MakeToast(string toastmsg)
	{
		jo.Call("makeToast",toastmsg);
	}

}
