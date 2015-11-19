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
	public GlobalVars globalvars;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = (globalvars.wetLawyers * Time.time).ToString();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.isTrigger || other.gameObject.name.Equals("Player")) {
			return;
		}

		ourtimer.wetLawyer ();
		globalvars.wetLawyers += 1;
		//scoreText.text = globalvars.wetLawyers.ToString();
	}
}
