using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	static float maxtime = 99;
	static float wettime = 33;
	static float maxplayer = 300;
	static float beerbonus = 50;

	public int score = 0;
	public bool carry = false;

	public float getMaxTime()
	{
		return maxtime;
	}
	
	public float getWetTime()
	{
		return wettime;
	}
	
	public float getMaxPlayer()
	{
		return maxplayer;
	}
	
	public float getBeerBonus()
	{
		return beerbonus;
	}
}
