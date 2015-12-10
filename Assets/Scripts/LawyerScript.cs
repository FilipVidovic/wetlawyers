using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LawyerScript : MonoBehaviour {

	private Rigidbody2D rigidBody;
	//public Canvas parentCanvas;
	//public GlobalVars globalvars;
	public RawImage drunkenessLevel;
	public float drunkeness;
	private BoxCollider2D boxCollider;
	//public PlayerScript player;
	//public RawImage drunkFrame;
	private float originX;
	private float originY;
	private float respawnTime;
	private float originalRotation;
	private bool floatingAround;
	private float maxrage = 50;
	private float rageLevel;
	public RawImage rage;
	public TrickColliderScriptLawyer aggroRange;
	public GameController gc;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent <BoxCollider2D> ();
		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
		rigidBody = GetComponent <Rigidbody2D> ();
		rigidBody.mass = 10 * drunkeness;
		//print (this);
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
			rageLevel -= 0.025f;

			if(rageLevel < 0)
				rageLevel = 0;

			rage.transform.localScale = new Vector3 (rageLevel/maxrage, 1, 1);
			aggroRange.setRadius (rageLevel);
		}
		//var wantedpos = Camera.main.WorldToScreenPoint (this.transform.position);
		//var wantedpos = this.transform.localPosition;

		//Debug.Log (this.transform.position);
		//Debug.Log (this.transform.localPosition);
		//drunkFrame.rectTransform.Rotate(new Vector3(0,0,0));
		//drunkFrame.rectTransform.rotation.z = -this.rigidBody.rotation;
		//drunkFrame.rectTransform.rotation.Set (drunkFrame.rectTransform.rotation.x, drunkFrame.rectTransform.rotation.y, 
		//                                       -this.rigidBody.rotation, drunkFrame.rectTransform.rotation.w);

		//drunkFrame.transform.localPosition = wantedpos;
		//drunk.transform.localScale = new Vector3(0.5f, 1, 1);

		//if (globalvars.carry == true && Input.GetKeyDown ("space")) {
		/*if (!Input.GetKey ("space") && !this.transform.parent.Equals(parentCanvas.transform)) {
			//if(globalvars.carry == true)
			//{
				print ("Hello Mother");
				this.transform.parent = parentCanvas.transform;
				//rigidBody.mass = 10;
				rigidBody.isKinematic = false;
				globalvars.carry = false;
			//}
		}*/
	}

	void FixedUpdate()
	{
		this.transform.parent.gameObject.transform.position = this.transform.position;
		this.transform.localPosition = new Vector2 (0, 0);

		if (floatingAround == true) {
			rigidBody.AddForce (Vector2.right * 450, ForceMode2D.Impulse);
		}
		//rigidBody.velocity = Vector2.zero;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		//if (globalvars.carry == false && other.gameObject.name.Equals("Player"))
		if (other.gameObject.name.Equals("Player"))
		{
			/*if(globalvars.carry == false && Input.GetKey ("space") && player.drunkeness >= this.drunkeness)
			{
				//if (Input.GetKey ("space")) {
					print ("Hello Father");
					this.transform.parent = other.transform;
					//this.transform.parent.SetParent(this.transform, false);

					//rigidBody.mass = 0;
					rigidBody.isKinematic = true;
					globalvars.carry = true;
				//}
			}*/
		}
		//print ("yippie");
		//this.GetComponentInChildren().
	}

	public void rotationSet(float newRotation)
	{
		rigidBody.rotation = newRotation;
	}

	public void iGotSoWet (float waitThisLong)
	{
		respawnTime = Time.time + waitThisLong;
		floatingAround = true;
		//rigidBody.AddForce (Vector2.right * 15000, ForceMode2D.Impulse);
	}

	public void goingAggro()
	{
		if(!rigidBody.IsTouching(gc.returnCollider()))
			rigidBody.AddForce (Vector2.Lerp(rigidBody.position, gc.playerPos() - rigidBody.position, 1)*15, ForceMode2D.Impulse);
		else
			rigidBody.AddForce (Vector2.Lerp(rigidBody.position, gc.playerPos() - rigidBody.position, 1)*5, ForceMode2D.Impulse);
	}
}
