using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreKeeperScript : MonoBehaviour {
	public List<int> scores;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.transform.gameObject);
		scores = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
