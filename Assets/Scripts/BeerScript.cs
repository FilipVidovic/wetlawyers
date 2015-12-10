using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeerScript : MonoBehaviour {

	public GameObject Figure;
	public GameController gc;
	private float respawnTime;
	private bool empty;
	public RawImage BeerPic;

	// Use this for initialization
	void Start () {
		empty = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (empty == true) {
			if ((respawnTime - Time.time) <= 0) {
				empty = false;
				BeerPic.gameObject.SetActive(true);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//player.rigidBody.mass += 150;

		if (other.isTrigger) {
			return;
		}

		gc.addDrunkeness ();
		respawnTime = Time.time + 20;
		empty = true;
		BeerPic.gameObject.SetActive(false);
		//this.child


		//player.addDrunkeness ();

		//print ("beeeeeeeeeeeeeeeeeeeer");

		//Destroy (Figure);
		//Destroy (this);
	}
}
