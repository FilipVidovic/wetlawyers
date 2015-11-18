using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	static float maxtime = 99;
	static float wettime = 33;

	public int score = 0;

	public float getMaxTime()
	{
		return maxtime;
	}
	
	public float getWetTime()
	{
		return wettime;
	}
}
