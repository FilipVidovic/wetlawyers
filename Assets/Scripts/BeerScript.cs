﻿using UnityEngine;
using System.Collections;

public class BeerScript : MonoBehaviour {

	public PlayerScript peter;
	public GameObject Figure;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		peter.rigidBody.mass += 150;
		print ("beeeeeeeeeeeeeeeeeeeer");

		Destroy (Figure);
		Destroy (this);
	}
}