using UnityEngine;
using System.Collections;

public class TrickColliderScriptLawyer : MonoBehaviour {

	private CircleCollider2D circleCollider;

	// Use this for initialization
	void Start () {
		circleCollider = GetComponent <CircleCollider2D> ();
	}
	
	public void setRadius(float newRadius)
	{
		circleCollider.radius = newRadius;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.transform.parent.gameObject.name.Equals ("Player")) {
			LawyerScript myLawyer = (LawyerScript)this.transform.parent.GetComponent ("LawyerScript");
			myLawyer.goingAggro();
		}

		//this.transform.parent.gameObject.GetComponent
	}
}
