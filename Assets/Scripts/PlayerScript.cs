using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float moveTime = 0.01f;
	private float inverseMoveTime;
	private Vector2 direction;
	private Vector3 rotvec;
	private float rotval;
	private float dir;

	private BoxCollider2D boxCollider;
	public Rigidbody2D rigidBody;
	public float myforce;

	// Use this for initialization
	void Start () {
		inverseMoveTime = 1f / moveTime;
		direction = new Vector2 (0, 0);
		rotvec = new Vector3 (0, 0, 0);
		rotval = 0;

		boxCollider = GetComponent <BoxCollider2D> ();
		//rigidBody = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame			FIXEDUPDATE
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftArrow))
			//direction = new Vector2 (-inverseMoveTime * Time.deltaTime, 0);
			//rotvec.Set (0, 0, 1);
			rotval = 1;
		else if (Input.GetKeyDown (KeyCode.RightArrow))
			//direction = new Vector2 (inverseMoveTime * Time.deltaTime, 0);
			//rotvec.Set (0, 0, -1);
			rotval = -1;
		else if (Input.GetKeyDown (KeyCode.DownArrow))
			//direction = new Vector2 (-inverseMoveTime * Time.deltaTime, -inverseMoveTime * Time.deltaTime);
			dir = -inverseMoveTime * Time.deltaTime;
		else if (Input.GetKeyDown (KeyCode.UpArrow))
			//direction = new Vector2 (inverseMoveTime * Time.deltaTime, inverseMoveTime * Time.deltaTime);
			dir = inverseMoveTime * Time.deltaTime;
		else if (Input.GetKeyUp (KeyCode.LeftArrow))
			//rotvec.Set (0, 0, 0);
			rotval = 0;
		else if (Input.GetKeyUp (KeyCode.RightArrow))
			//rotvec.Set (0, 0, 0);
			rotval = 0;
		else if (Input.GetKeyUp (KeyCode.DownArrow))
			//direction = new Vector2 (0, 0);
			dir = 0;
		else if (Input.GetKeyUp (KeyCode.UpArrow))
			//direction = new Vector2 (0, 0);
			dir = 0;

		moving ();
		rotating ();
	}

	private bool moving()
	{
		float eulerz = Mathf.Deg2Rad * this.transform.eulerAngles.z;
		//print ("Deg: " + this.transform.eulerAngles.z + "\nRad: " + eulerz);


		//this.transform.localPosition += new Vector3(Mathf.Cos(eulerz) * direction.x, Mathf.Sin(eulerz) * direction.y, 0);

		rigidBody.AddRelativeForce (new Vector3 (dir, 0, 0) * myforce);
		//this.gameObject.transform.
		//Vector2 start = transform.position;
		//Vector2 end = start - new Vector2(x,y);

		//StartCoroutine(smoothmoving(end));
		return true;
	}

	private bool rotating()
	{
		//this.transform.localRotation = this.transform.localRotation * Quaternion.Euler (rotvec);
		//rigidBody.rotation = rigidBody.rotation * Quaternion.Euler (rotvec);
		rigidBody.rotation += rotval;
		//this.transform.localEulerAngles.z = this.transform.localEulerAngles.z + 1;
		return true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		print ("yippie");
	}

	/*private IEnumerator smoothmoving(Vector3 end)
	{

	}*/
}
