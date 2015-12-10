using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	static float maxtime = 60;
	static float wettime = 20;
	//static float maxplayer = 300;
	//static float beerbonus = 50;
	int wetLawyers = 0;
	int Score;
	int previousSecond = 0;
	private bool carry;
	public Text scoreText;
	float endTime;
	public RawImage timebar;
	public PlayerScript player;
	List<Collider2D> carryableLawyers;	//id?
	//List<Collider2D> hinderingWalls;
	private int hinderingWalls;
	static float addedDrunkeness = 20;
	static float maxdrunkeness = 100;
	private float moveTime = 0.01f;
	private float inverseMoveTime;
	private float rotval;
	private Vector2 movedir;
	private LawyerScript carriedLawyer;
	private int indexCarriedLawyer;
	private bool losing;
	private float waterEndTime;
	public RawImage drunkenessLevel;
	private float drunkeness;

	//public BeerScript beer2hide;
	//float beerhidingtime;


	// Use this for initialization
	void Start () {
		endTime = Time.time + maxtime;
		//beerhidingtime = Time.time + 5;
		carryableLawyers = new List<Collider2D> ();
		//hinderingWalls = new List<Collider2D> ();
		hinderingWalls = 0;
		inverseMoveTime = 1f / moveTime;
		rotval = 0;
		player.setMyForce (4000);
		carry = false;
		wetLawyers = 0;
		Score = 0;
		losing = false;
		drunkenessLevel.transform.localScale = new Vector3 (0, 1, 1);
		drunkeness = 50;	//0
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > previousSecond + 1) {
			previousSecond += 1;
			Score += wetLawyers;
			scoreText.text = Score.ToString();
		}

		/*if (Time.time > beerhidingtime) {
			//beer2hide.enabled = false;
			beer2hide.gameObject.SetActive(true);
		}*/
		
		if ((endTime - Time.time) > 0) {
			timebar.transform.localScale = new Vector3 ((endTime - Time.time) / maxtime, 1, 1);
		} else
			gameOver ();

		if (losing == true) {
			if ((waterEndTime - Time.time) > 0) {
				player.thisWasUnfortunate();
			} else
				gameOver ();
		}

		drunkeness -= 0.015f;
		if (drunkeness < 0) {
			drunkeness = 0;
		}

		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
	}

	void FixedUpdate()
	{
		if (losing == true) {
			return;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			player.rotating(-1f);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			player.rotating(1f);
		}
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			player.moving(1f, (Random.value * (drunkeness/2 - (-drunkeness/2)) + -drunkeness/2)/10);
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			player.moving(-1f, (Random.value * (drunkeness/2 - (-drunkeness/2)) + -drunkeness/2)/10);
		}
		
		if (!Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
			player.stopMoving();
		}

		if (hinderingWalls > 0) {
			return;
		}

		if (carry == false) {
			if (carryableLawyers.Count > 0) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					if(carryableLawyers.Count > 1)
					{
						indexCarriedLawyer = closestLawyer();
					}
					else
					{
						indexCarriedLawyer = 0;
					}

					LawyerScript lawyerInSight = (LawyerScript)carryableLawyers[indexCarriedLawyer].GetComponent("LawyerScript");

					if(drunkeness >= lawyerInSight.drunkeness)
					{
						carry = true;
						carryableLawyers[indexCarriedLawyer].gameObject.transform.parent.gameObject.SetActive(false);
					}
				}
			}
		}
		else if (carry == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				carry = false;
				carryableLawyers[indexCarriedLawyer].gameObject.transform.parent.gameObject.SetActive(true);
				carryableLawyers[indexCarriedLawyer].gameObject.transform.parent.gameObject.transform.position = 
					new Vector2(player.transform.position.x+Mathf.Round(Mathf.Cos(Mathf.Deg2Rad * player.getRotation())*30),
					            player.transform.position.y+Mathf.Round(Mathf.Sin(Mathf.Deg2Rad * player.getRotation())*30));
				//carryableLawyers[0].gameObject.transform.parent.gameObject.transform.position = 
				//		new Vector2(player.transform.position.x+30, player.transform.position.y);
				carriedLawyer = (LawyerScript)carryableLawyers[indexCarriedLawyer].GetComponent("LawyerScript");
				carriedLawyer.rotationSet(player.getRotation() + 180);
				carryableLawyers.Remove(carryableLawyers[indexCarriedLawyer]);
				//rigidBody.velocity = new Vector2(Mathf.Cos(rigidBody.rotation)+10,Mathf.Sin(rigidBody.rotation)+10);
			}
		}

		//print(player.getRotation());
		/*print ("Player X: " + player.transform.position.x + 
			"\nPlayer Y: " + player.transform.position.y +
		    "\nPlayer rotation: " + player.getRotation() +
		       "\nResult X: " + (player.transform.position.x+Mathf.Cos(player.getRotation())*30) +
		       "\nResult Y: " + (player.transform.position.y+Mathf.Sin(player.getRotation())*30) +
		       "\nCos: " + (Mathf.Cos(player.getRotation())*30) +
		       "\nSin: " + (Mathf.Sin(player.getRotation())*30) +
		       "\nCos: " + (Mathf.Round(Mathf.Cos(Mathf.Deg2Rad * player.getRotation())*30)) +
		       "\nSin: " + (Mathf.Round(Mathf.Sin(Mathf.Deg2Rad * player.getRotation())*30)));*/
			
		//Mathf.Deg2Rad * 
			/*if (Input.GetKeyUp (KeyCode.RightArrow) && Input.GetKeyUp (KeyCode.LeftArrow))
		{
			rotval = 0;
		}*/
	}

	private int closestLawyer()
	{
		int returnvalue = 0;

		for(int i = 1; i < carryableLawyers.Count; ++i)
		{
			if(Vector2.Distance(carryableLawyers[returnvalue].gameObject.transform.position, player.transform.position)
			   > Vector2.Distance(carryableLawyers[i].gameObject.transform.position, player.transform.position))
			{
				returnvalue = i;
			}
		}

		return returnvalue;
	}

	public void wetLawyer(LawyerScript wettedLawyer)
	{
		//endTime += wettime;
		
		/*if (endTime - Time.time > wettime) {
			endTime = Time.time + wettime;
		}*/
		if ((endTime + wettime - Time.time) > maxtime)
			endTime += maxtime + Time.time - endTime;
		else
			endTime += wettime;

		++wetLawyers;

		wettedLawyer.iGotSoWet (20f);
	}

	public void wetPlayer()
	{
		losing = true;
		waterEndTime = Time.time + 2;
	}

	public void entersCarryArea(Collider2D lawyer)	//id?
	{
		carryableLawyers.Add (lawyer);

		/*if (carry == false)
			carry = true;*/
	}

	public void leavesCarryArea(Collider2D lawyer)
	{
		carryableLawyers.Remove (lawyer);

		/*if (carryableLawyers.Count == 0)
			carry = false;*/
	}

	public void wallIsBlocking()
	{
		++hinderingWalls;
	}
	
	public void wallStoppedBlocking()
	{
		--hinderingWalls;
	}
	
	public void addDrunkeness()	//float value overloaded by calling alcohol?
	{
		//player.addDrunkeness (maxdrunkeness, addedDrunkeness);
		drunkeness += addedDrunkeness;
		
		if (drunkeness > maxdrunkeness) {
			drunkeness = maxdrunkeness;
		}
		
		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1); 
		/*
		 /rigidBody.mass += globalvars.getBeerBonus ();
		
		//if (rigidBody.mass > globalvars.getMaxPlayer ())
		//	rigidBody.mass = globalvars.getMaxPlayer ();
		//print (
		drunkeness += addedDrunkeness;

		if (drunkeness > maxdrunkeness) {
			drunkeness = maxdrunkeness;
		}

		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);*/
	}

	void gameOver()
	{
		GameObject scoreKeeper = GameObject.Find ("ScoreKeeper");
		ScoreKeeperScript sks = (ScoreKeeperScript)scoreKeeper.GetComponent ("ScoreKeeperScript");
		sks.scores.Add (int.Parse(scoreText.text));
		Application.LoadLevel (2);
	}

	public Vector2 playerPos()
	{
		return player.returnPos ();
	}
	
	public BoxCollider2D returnCollider()
	{
		return player.returnCollider();
	}
}
