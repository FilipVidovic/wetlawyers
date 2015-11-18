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
using UnityEngine.UI;
using System.Collections;

public class HinterseeScript : MonoBehaviour {

	public PlayerTimer ourtimer;
	public GlobalVars globalvars;
	public Text scoreText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		ourtimer.wetLawyer ();
		globalvars.score += 1;
		scoreText.text = globalvars.score.ToString();
	}
}
