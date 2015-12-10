using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndScript : MonoBehaviour {
	public Text top10;

	// Use this for initialization
	void Start () {
		GameObject scoreKeeper = GameObject.Find ("ScoreKeeper");
		ScoreKeeperScript sks = (ScoreKeeperScript)scoreKeeper.GetComponent ("ScoreKeeperScript");
		List<int> sortedList = new List<int>();

		for (int i = 0; i < sks.scores.Count; ++i) {
			sortedList.Add(i);
		}

		for (int i = 0; i < sks.scores.Count; ++i) {
			int j = i;
			print ("ey b0ss" + i);
			for(int k = i; k < sks.scores.Count; ++k)
			{
				if(sks.scores[sortedList[j]] < sks.scores[sortedList[k]])
				{
					j = k;
					print ("gib pusi pls" + k);
				}
			}
			int help = sortedList[i];
			sortedList[i] = sortedList[j];
			sortedList[j] = help;

		}

		top10.text = "Top 10\n\n";

		int topzahl = 10;
		if (sortedList.Count < 10)
			topzahl = sortedList.Count;

		for (int i = 0; i < topzahl; ++i) {
			top10.text += "Platz " + (i+1) + " - Durchgang " + (sortedList[i]+1) + " - Punkte: " + sks.scores[sortedList[i]] + "\n";
		}


		//sortedList.Sort ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel (1);
		}
	}
}
