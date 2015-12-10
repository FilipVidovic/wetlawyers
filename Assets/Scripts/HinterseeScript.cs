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

	public GameController gc;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = (globalvars.wetLawyers * Time.time).ToString();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		/*if (other.isTrigger || other.gameObject.name.Equals("Player")) {
			return;
		}*/

		if(other.transform.parent.gameObject.name.StartsWith("Lawyer"))
		{
			gc.wetLawyer ((LawyerScript)other.GetComponent ("LawyerScript"));
		}

		if(other.transform.parent.gameObject.name.Equals("Player"))
		{
			gc.wetPlayer();
		}

		//scoreText.text = globalvars.wetLawyers.ToString();
	}
}
