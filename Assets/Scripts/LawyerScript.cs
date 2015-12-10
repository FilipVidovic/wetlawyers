using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LawyerScript : MonoBehaviour {

	public float drunkeness;
	public GameController gc;
	public RawImage drunkenessLevel;
	public RawImage rage;
	public TrickColliderScriptLawyer aggroRange;

	private bool floatingAround;
	private BoxCollider2D boxCollider;
	private float maxrage = 50;
	private float originalRotation;
	private float originX;
	private float originY;
	private float rageLevel;
	private float respawnTime;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent <BoxCollider2D> ();
		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
		rigidBody = GetComponent <Rigidbody2D> ();
		rigidBody.mass = 10 * drunkeness;
		originX = this.transform.parent.gameObject.transform.position.x;
		originY = this.transform.parent.gameObject.transform.position.y;
		originalRotation = rigidBody.rotation;
		floatingAround = false;
		rageLevel = 0;
		rage.transform.localScale = new Vector3 (0, 1, 1);
		aggroRange.setRadius (rageLevel);
	}

	// Update is called once per frame
	void Update () {
		if (floatingAround == true) {
			if ((respawnTime - Time.time) <= 0) {
				this.transform.parent.gameObject.transform.position = new Vector2(originX, originY);
				rigidBody.rotation = originalRotation;
				rigidBody.velocity = Vector2.zero;
				floatingAround = false;
				rageLevel = maxrage;
				rage.transform.localScale = new Vector3 (rageLevel/maxrage, 1, 1);
				aggroRange.setRadius (rageLevel);
			}
		}

		if (rageLevel > 0) {
			rageLevel -= 0.015f;

			if(rageLevel < 0)
				rageLevel = 0;

			rage.transform.localScale = new Vector3 (rageLevel/maxrage, 1, 1);
			aggroRange.setRadius (rageLevel);
		}
	}

	void FixedUpdate()
	{
		this.transform.parent.gameObject.transform.position = this.transform.position;
		this.transform.localPosition = new Vector2 (0, 0);

		if (floatingAround == true) {
			rigidBody.AddForce (Vector2.right * 450, ForceMode2D.Impulse);
		}
	}

	public void rotationSet(float newRotation)
	{
		rigidBody.rotation = newRotation;
	}

	public void iGotSoWet (float waitThisLong)
	{
		respawnTime = Time.time + waitThisLong;
		floatingAround = true;
	}

	public void goingAggro()
	{
		if(!rigidBody.IsTouching(gc.returnCollider()))
			rigidBody.AddForce (Vector2.Lerp(rigidBody.position, gc.playerPos() - rigidBody.position, 1)*15, ForceMode2D.Impulse);
		else
			rigidBody.AddForce (Vector2.Lerp(rigidBody.position, gc.playerPos() - rigidBody.position, 1)*5, ForceMode2D.Impulse);
	}
}
