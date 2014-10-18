/************************************************************************************

Filename    :   OVRDebugStreamer.cs
Content     :   Print messages to screen
Created     :   January 8, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.1 (the "License"); 
you may not use the Oculus VR Rift SDK except in compliance with the License, 
which is provided at the time of installation or download, or which 
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculusvr.com/licenses/LICENSE-3.1 

Unless required by applicable law or agreed to in writing, the Oculus VR SDK 
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 
Brought in from the following code:

	DebugStreamer in c#
	Ankit Goel
	ankit.goel@apra-infotech.com
	· displays on screen a history of 'numberOfLines' of whatever text is sent to 'message'
	· 'showLineMovement' adds a rotating mark at the end of the lines of text, so repetitive 
	   message can be seen to be moving

	· to use, add this script to a game object, then from another script simply add 
	"DebugStreamer.message = "text to display";
	This script is the c# version of the debug streamer provided by Jamie McCarter.

************************************************************************************/

using UnityEngine;
using System.Collections;

public class OVRDebugStreamer : MonoBehaviour 
{
	public static string message;
	public bool showLineMovement;
	public TextAnchor anchorAt = TextAnchor.LowerLeft;
	public int numberOfLines = 5;
	public int pixelOffset = 20;
	public float timeout = 0.0f;
	
	private GameObject guiObj;
	private GUIText guiTxt;
	private TextAnchor _anchorAt;
	private float _pixelOffset;
	private bool _showLineMovement;
	private string	_message;
	private ArrayList messageHistory = new ArrayList ();
	private int messageHistoryLength;
	private string	displayText;
	private int	patternIndex = 0;
	private string[] pattern = new string[] {"-", "\\", "|", "/"};
	private float currentTimeout = 0.0f;
	
	// Use this for initialization
	void Awake ()
	{
		guiObj = new GameObject("Debug Streamer");
		guiObj.AddComponent("GUIText");
		guiObj.transform.position = Vector3.zero;
		guiObj.transform.localScale = new Vector3(0, 0, 1);
		guiObj.name = "Debug Streamer";
		guiTxt = guiObj.guiText;
		_anchorAt = anchorAt;
		_message = message;
		SetPosition();
	}
	
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//	if anchorAt or pixelOffset has changed while running, update the text position
		if(_anchorAt!=anchorAt || _pixelOffset!=pixelOffset)
		{
			_anchorAt = anchorAt;
			_pixelOffset = pixelOffset;
			SetPosition();
		}
			
		//	if the message has changed, update the display
		if(_message!=message)
		{
			_message = message;
			currentTimeout = timeout;
			
			if(showLineMovement)
			{
				messageHistory.Insert(0,message + "\t" + pattern[patternIndex]);
				messageHistoryLength = messageHistory.Count;
				//messageHistoryLength = messageHistory.Unshift(message + "\t" + pattern[patternIndex]);
			}
			else
				messageHistory.Insert(0, message);
				messageHistoryLength = messageHistory.Count;
				//messageHistoryLength = messageHistory.Unshift(message);
			
			patternIndex = (patternIndex + 1) % 4;
			while(messageHistoryLength>numberOfLines)
				{
					//messageHistory.Pop();
					messageHistory.RemoveAt(messageHistory.Count - 1);
					messageHistoryLength = messageHistory.Count;
				}
		
			//	create the multi-line text to display
			displayText = "";
			for(int i = 0; i<messageHistory.Count; i++)
				{
				if(i==0)
					displayText = messageHistory[i] as string;
				else
					displayText = (messageHistory[i] as string) + "\n" + displayText;
				}
			
			guiTxt.text = displayText;
		}

		
		// We will remove everything from the list if the time goes out
		if(timeout > 0.0f)
		{
			if(currentTimeout != 0.0f)
			{
				currentTimeout -= Time.deltaTime;
				if(currentTimeout < 0.0f)
				{
					// Clear the display text
					currentTimeout = 0.0f;
					messageHistory.Clear();
					displayText = "";
					guiTxt.text = displayText;
				}
			}				
		}
	}
	
	public void OnDisable()
	{
		if(guiObj!=null)
			GameObject.DestroyImmediate(guiObj.gameObject);
	}
	
	public void SetPosition()
	{
		switch(anchorAt)
		{
		case TextAnchor.UpperLeft:
			guiObj.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Left;
			guiTxt.pixelOffset = new Vector2(pixelOffset, -pixelOffset);
			break;
		case TextAnchor.UpperCenter:
			guiObj.transform.position = new Vector3(0.5f, 1.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Center;
			guiTxt.pixelOffset = new Vector2(0, -pixelOffset);
			break;
		case TextAnchor.UpperRight:
			guiObj.transform.position = new Vector3(1.0f, 1.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Right;
			guiTxt.pixelOffset = new Vector2(-pixelOffset, -pixelOffset);
			break;
		case TextAnchor.MiddleLeft:
			guiObj.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Left;
			guiTxt.pixelOffset = new Vector2(pixelOffset, 0.0f);
			break;
		case TextAnchor.MiddleCenter:
			guiObj.transform.position = new Vector3(0.5f, 0.5f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Center;
			guiTxt.pixelOffset = new Vector2(0, 0);
			break;
		case TextAnchor.MiddleRight:
			guiObj.transform.position = new Vector3(1.0f, 0.5f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Right;
			guiTxt.pixelOffset = new Vector2(-pixelOffset, 0.0f);
			break;
		case TextAnchor.LowerLeft:
			guiObj.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Left;
			guiTxt.pixelOffset = new Vector2(pixelOffset, pixelOffset);
			break;
		case TextAnchor.LowerCenter:
			guiObj.transform.position = new Vector3(0.5f, 0.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Center;
			guiTxt.pixelOffset = new Vector2(0, pixelOffset);
			break;
		case TextAnchor.LowerRight:
			guiObj.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
			guiTxt.anchor = anchorAt;
			guiTxt.alignment = TextAlignment.Right;
			guiTxt.pixelOffset = new Vector2(-pixelOffset, pixelOffset);
			break;
		}
	}
}
