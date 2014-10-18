using UnityEngine;
using System.Collections;

public class OVRVolumeControl : MonoBehaviour {
	private const float 		ShowPopupTime = 3;
	private const float			PopupDepth = 1.45f;
	private const int 			MaxVolume = 15;
	private const int 			NumVolumeImages = MaxVolume + 1;

	private Transform			MyTransform = null;
	private int 				CurrentVolume;
	private float 				PopupVisibleTime;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad( gameObject );
		MyTransform = transform;
		renderer.enabled = false;
		PopupVisibleTime = 0;

		// OVRDevice.GetVolume() will return -1 if the volume listener hasn't initialized yet,
		// which sometimes takes place after a frame has run in Unity.  So instead
		// of initializing with OVRDevice.GetVolume(), we'll wait until we get
		// a valid volume when we update the position.
		CurrentVolume = -1;
	}

	// Updates the position of the volume popup
	// Should be called by the current camera controller in LateUpdate
	public void UpdatePosition ( Quaternion cameraRot, Vector3 cameraPosition )
	{
		// OVRDevice.GetVolume() will return -1 if the volume listener hasn't initialized yet,
		// which sometimes takes place after a frame has run in Unity.
		int volume = OVRDevice.GetVolume();
		if ( volume != CurrentVolume )
		{
			// don't show the volume popup on the first valid volume we get
			if ( CurrentVolume != -1 )
			{
				renderer.material.mainTextureOffset = new Vector2( 0, ( float )( MaxVolume - volume ) / ( float )NumVolumeImages );
				PopupVisibleTime = Time.realtimeSinceStartup + ShowPopupTime;
			}
			CurrentVolume = volume;
		}

		renderer.enabled = ( PopupVisibleTime > Time.realtimeSinceStartup );
		if ( renderer.enabled )
		{
			// place in front of camera on the horizon with no pitch or roll
			Vector3	ang = cameraRot.eulerAngles;
			Quaternion rot = Quaternion.Euler( 0, ang.y, 0 );
			MyTransform.forward = rot * Vector3.forward;
			MyTransform.position = cameraPosition + ( MyTransform.forward * PopupDepth );
		}
	}
}
