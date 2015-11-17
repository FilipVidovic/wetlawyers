using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LawyerScript : MonoBehaviour {

	public Rigidbody2D rigidBody;
	public RawImage drunk;

	// Use this for initialization
	void Start () {
		rigidBody.mass = 10;
	}
	
	// Update is called once per frame
	void Update () {
		drunk.transform.localScale = new Vector3(0.5f, 1, 1);
	}
}
