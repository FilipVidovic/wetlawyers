using UnityEngine;
using System.Collections;

public class HinterseeScript : MonoBehaviour {

	public GameController gc;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.transform.parent.gameObject.name.StartsWith("Lawyer"))
		{
			gc.wetLawyer ((LawyerScript)other.GetComponent ("LawyerScript"));
		}

		if(other.transform.parent.gameObject.name.Equals("Player"))
		{
			gc.wetPlayer();
		}
	}
}
