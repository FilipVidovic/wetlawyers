using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LawyerScript : MonoBehaviour {

	public Rigidbody2D rigidBody;
	public Canvas parentCanvas;
	public GlobalVars globalvars;
	public RawImage drunkenessLevel;
	public float drunkeness;
	public PlayerScript player;
	//public RawImage drunkFrame;

	// Use this for initialization
	void Start () {
		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
		rigidBody.mass = 10 * drunkeness;
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

		//if (globalvars.carry == true && Input.GetKeyDown ("space")) {
		if (!Input.GetKey ("space") && !this.transform.parent.Equals(parentCanvas.transform)) {
			//if(globalvars.carry == true)
			//{
				print ("Hello Mother");
				this.transform.parent = parentCanvas.transform;
				//rigidBody.mass = 10;
				rigidBody.isKinematic = false;
				globalvars.carry = false;
			//}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//if (globalvars.carry == false && other.gameObject.name.Equals("Player"))
		if (other.gameObject.name.Equals("Player"))
		{
			if(globalvars.carry == false && Input.GetKey ("space") && player.drunkeness >= this.drunkeness)
			{
				//if (Input.GetKey ("space")) {
					print ("Hello Father");
					this.transform.parent = other.transform;
					//this.transform.parent.SetParent(this.transform, false);

					//rigidBody.mass = 0;
					rigidBody.isKinematic = true;
					globalvars.carry = true;
				//}
			}
		}
		//print ("yippie");
		//this.GetComponentInChildren().
	}
}
