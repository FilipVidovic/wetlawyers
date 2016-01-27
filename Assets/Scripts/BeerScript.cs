using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeerScript : MonoBehaviour {

	public GameController gc;
	public GameObject Figure;
	public Image BeerPic;

	private bool empty;
	private float respawnTime;

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
		if (other.isTrigger || empty == true) {
			return;
		}

		gc.addDrunkeness ();
		respawnTime = Time.time + 30;
		empty = true;
		BeerPic.gameObject.SetActive(false);
	}
}
