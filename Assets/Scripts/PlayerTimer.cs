using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTimer : MonoBehaviour {

	public RawImage timebar;
	public float endTime;
	//public GlobalVars globalvars;
	public float maxtime = 99;
	public float wettime = 33;

	// Use this for initialization
	void Start () {
		endTime = Time.time + maxtime;
	}
	
	// Update is called once per frame
	void Update () {
		if ((endTime - Time.time) > 0) {
			timebar.transform.localScale = new Vector3 ((endTime - Time.time) / maxtime, 1, 1);
		} else
			endTime += maxtime;
		//thistime.transform.localScale = new Vector3(0, 1, 1);
	}

	public void wetLawyer()
	{
		endTime += wettime;

		if (endTime - Time.time > maxtime) {
			endTime = Time.time + maxtime;
		}
	}
}
