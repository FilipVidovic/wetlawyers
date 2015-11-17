using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LawyerScript : MonoBehaviour {

	public Rigidbody2D rigidBody;
	//public RawImage drunkFrame;

	// Use this for initialization
	void Start () {
		rigidBody.mass = 10;
		//print (this);
	}
	
	// Update is called once per frame
	void Update () {
		//var wantedpos = Camera.main.WorldToScreenPoint (this.transform.position);
		//var wantedpos = this.transform.localPosition;

		//Debug.Log (this.transform.position);
		//Debug.Log (this.transform.localPosition);
		//drunkFrame.rectTransform.Rotate(new Vector3(0,0,0));
		//drunkFrame.rectTransform.rotation.z = -this.rigidBody.rotation;
		//drunkFrame.rectTransform.rotation.Set (drunkFrame.rectTransform.rotation.x, drunkFrame.rectTransform.rotation.y, 
		//                                       -this.rigidBody.rotation, drunkFrame.rectTransform.rotation.w);

		//drunkFrame.transform.localPosition = wantedpos;
		//drunk.transform.localScale = new Vector3(0.5f, 1, 1);
	}
}
