using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//private float moveTime = 0.01f;
	//private float inverseMoveTime;
	//private Vector2 direction;
	//private Vector3 rotvec;
	//private float rotval;
	//private float dir;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private float myforce;
	
	//public RawImage drunkFrame;
	//public RawImage timeFrame;
	//public RawImage thistime;
	//public RawImage drunkenessLevel;
	//private Quaternion quatty;
	public GameController gc;
	//public GlobalVars globalvars;

	//private float rotdelay;
	//private float movedelay;
	//public float drunkeness;

	// Use this for initialization
	void Start () {
		//inverseMoveTime = 1f / moveTime;
		//direction = new Vector2 (0, 0);
		//rotvec = new Vector3 (0, 0, 0);
		//rotval = 0;

		//rotdelay = 0;
		//movedelay = 0;
		//drunkeness = 20;

		boxCollider = GetComponent <BoxCollider2D> ();
		rigidBody = GetComponent <Rigidbody2D> ();
		//quatty = new Quaternion (0, 0, 0, 1);
		
		//drunkenessLevel.transform.localScale = new Vector3 (0, 1, 1);
	}
	
	// Update is called once per frame			FIXEDUPDATE
	/*void FixedUpdate () {
		drunkFrame.transform.rotation = quatty;
		timeFrame.transform.rotation = quatty;
		rotval = 0;
		dir = 0;

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
			movedelay = drunkeness/2;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			rotdelay = drunkeness/3;
		}
		
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			rigidBody.velocity = Vector2.zero;
			//rigidBody.velocity = new Vector2(Mathf.Cos(rigidBody.rotation)+10,Mathf.Sin(rigidBody.rotation)+10);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			rigidBody.velocity = Vector2.zero;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//direction = new Vector2 (-inverseMoveTime * Time.deltaTime, 0);
			//rotvec.Set (0, 0, 1);
			if(rotdelay > 0)
			{
				rotdelay -= 1;
			}
			else
				rotval = 1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (rotdelay > 0) {
				rotdelay -= 1;
			} else
				rotval = -1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (movedelay > 0) {
				movedelay -= 1;
			} else
				dir = -inverseMoveTime * Time.deltaTime;
		}
			//direction = new Vector2 (-inverseMoveTime * Time.deltaTime, -inverseMoveTime * Time.deltaTime);
			
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (movedelay > 0) {
				movedelay -= 1;
			} else
				dir = inverseMoveTime * Time.deltaTime;
		}
			//direction = new Vector2 (inverseMoveTime * Time.deltaTime, inverseMoveTime * Time.deltaTime);

		moving ();
		rotating ();

		drunkeness -= 0.005f;
		if (drunkeness < 0) {
			drunkeness = 0;
		}
		
		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
	}*/

	/*private bool moving()
	{
		float eulerz = Mathf.Deg2Rad * this.transform.eulerAngles.z;
		//print ("Deg: " + this.transform.eulerAngles.z + "\nRad: " + eulerz);


		//this.transform.localPosition += new Vector3(Mathf.Cos(eulerz) * direction.x, Mathf.Sin(eulerz) * direction.y, 0);

		rigidBody.AddRelativeForce (new Vector2 (0, dir) * myforce);
		//this.gameObject.transform.
		//Vector2 start = transform.position;
		//Vector2 end = start - new Vector2(x,y);

		//StartCoroutine(smoothmoving(end));
		return true;
	}*/

	/*private bool rotating()
	{
		//this.transform.localRotation = this.transform.localRotation * Quaternion.Euler (rotvec);
		//rigidBody.rotation = rigidBody.rotation * Quaternion.Euler (rotvec);
		rigidBody.rotation += rotval;
		//this.transform.localEulerAngles.z = this.transform.localEulerAngles.z + 1;
		return true;
	}*/

	public void rotating (float rotval)
	{
		rigidBody.rotation += rotval;
	}
	
	public void moving (float dir, float offset)
	{
		//float eulerz = Mathf.Deg2Rad * this.transform.eulerAngles.z;
		rigidBody.AddRelativeForce (new Vector2 (offset, dir) * myforce);

		//print ("HELO FEGOTS! " + rigidBody.transform.position);
		//print ("WHY LISA WHY??? " + this.transform.parent.gameObject.transform.position);
		//print (this.transform.position);
		//print (this.transform.localPosition);
		//this.transform.parent.gameObject.transform.position = this.transform.position - this.transform.localPosition;
		this.transform.parent.gameObject.transform.position = this.transform.position;
		this.transform.localPosition = new Vector2 (0, 0);
		//GameObject obj = this.transform.parent.gameObject;
		//obj.transform.Translate (new Vector2(-5, -5));
	}
	
	public void stopMoving ()
	{
		rigidBody.velocity = Vector2.zero;
		this.transform.localPosition = new Vector2 (0, 0);
	}

	/*void OnTriggerEnter2D (Collider2D other)
	{
		if(other.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.entersCarryArea (other);

		if (other.transform.gameObject.name.Equals ("Wall"))
			gc.wallIsBlocking ();
	}*/

	public void GotSomething (Collider2D something)
	{
		if (something.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.entersCarryArea (something);
		
		if (something.transform.gameObject.name.Equals ("Wall"))
			gc.wallIsBlocking ();
	}
	
	/*void OnTriggerExit2D (Collider2D other)
	{
		if(other.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.leavesCarryArea (other);
		
		if (other.transform.gameObject.name.Equals ("Wall"))
			gc.wallStoppedBlocking ();
	}*/

	public void LostSomething (Collider2D something)
	{
		if(something.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.leavesCarryArea (something);
		
		if (something.transform.gameObject.name.Equals ("Wall"))
			gc.wallStoppedBlocking ();
	}

	/*public void addDrunkeness(float maxdrunkeness, float addedDrunkeness = 20)
	{
		//rigidBody.mass += globalvars.getBeerBonus ();
		
		//if (rigidBody.mass > globalvars.getMaxPlayer ())
		//	rigidBody.mass = globalvars.getMaxPlayer ();
		//print (
		drunkeness += addedDrunkeness;

		if (drunkeness > maxdrunkeness) {
			drunkeness = maxdrunkeness;
		}

		drunkenessLevel.transform.localScale = new Vector3 (drunkeness / 100f, 1, 1);
	}*/

	public float getRotation()
	{
		return rigidBody.rotation + 90;;
	}

	public void setMyForce(float force)
	{
		myforce = force;
	}
	
	/*private IEnumerator smoothmoving(Vector3 end)
	{

	}*/
	
	public void thisWasUnfortunate ()
	{
		rigidBody.AddForce (Vector2.right * 450, ForceMode2D.Impulse);
		this.transform.parent.gameObject.transform.position = this.transform.position;
		this.transform.localPosition = new Vector2 (0, 0);
	}

	public Vector2 returnPos()
	{
		return rigidBody.position;
	}

	public BoxCollider2D returnCollider()
	{
		return boxCollider;
	}
}
