using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	static float maxtime = 60;
	static float wettime = 20;
	static float maxplayer = 300;
	static float beerbonus = 50;

	public int wetLawyers = 0;
	public int Score = 0;
	public int previousSecond = 0;
	public bool carry = false;
	public Text scoreText;

	void Update () {
		if (Time.time > previousSecond + 1) {
			previousSecond += 1;
			Score += wetLawyers;
			//print (Score);
			scoreText.text = Score.ToString();
		}
	}

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
