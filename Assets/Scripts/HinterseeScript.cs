/*
 * 20 lawyer
 * 
 * Betrunkenheitslevel (masse)
 * 
 * Biere powerups und effekte
 * 
 * game over (scene neustart)
 * 
 * punkte
 * 
 * optional - wegtreiben
 * optional - singleton
 * optional - globale variablen
 */

using UnityEngine;
using System.Collections;

public class HinterseeScript : MonoBehaviour {

	public PlayerTimer ourtimer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		ourtimer.wetLawyer ();
	}
}
