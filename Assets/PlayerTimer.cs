using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTimer : MonoBehaviour {

	public RawImage timebar;
	public float endTime;

	// Use this for initialization
	void Start () {
		endTime = Time.time + 60;
	}
	
	// Update is called once per frame
	void Update () {
		if ((endTime - Time.time) > 0) {
			timebar.transform.localScale = new Vector3 ((endTime - Time.time) / 60f, 1, 1);
		} else
			endTime += 60;
		//thistime.transform.localScale = new Vector3(0, 1, 1);
	}

	public void wetLawyer()
	{
		endTime += 15;

		if (endTime - Time.time > 60) {
			endTime = Time.time + 60;
		}
	}
}
