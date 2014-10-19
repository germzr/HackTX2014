using UnityEngine;
using System.Collections;

public class RedditPicturePost : MonoBehaviour {

	public Material ImageMat;
	public TextMesh Text;
	
	void Start () {
	}

	public void FindReferences() {
		ImageMat = transform.FindChild("Image").renderer.material;
		Text = transform.FindChild("Title").GetComponent<TextMesh>();
	}

	void Update () {
	
	}
}
