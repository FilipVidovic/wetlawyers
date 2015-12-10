using UnityEngine;
using System.Collections;

public class TrickColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		PlayerScript myPlayer = (PlayerScript)this.transform.parent.GetComponent ("PlayerScript");
		myPlayer.GotSomething (other);
		///this.transform.parent
		/// carriedLawyer = (LawyerScript)carryableLawyers[indexCarriedLawyer].GetComponent("LawyerScript");
		//carriedLawyer.rotationSet(player.getRotation() + 180);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		PlayerScript myPlayer = (PlayerScript)this.transform.parent.GetComponent ("PlayerScript");
		myPlayer.LostSomething (other);
	}
}
