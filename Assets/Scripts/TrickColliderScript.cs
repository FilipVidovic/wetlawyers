using UnityEngine;
using System.Collections;

public class TrickColliderScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		PlayerScript myPlayer = (PlayerScript)this.transform.parent.GetComponent ("PlayerScript");
		myPlayer.GotSomething (other);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		PlayerScript myPlayer = (PlayerScript)this.transform.parent.GetComponent ("PlayerScript");
		myPlayer.LostSomething (other);
	}
}
