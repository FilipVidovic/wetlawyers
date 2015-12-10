using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public GameController gc;

	private BoxCollider2D boxCollider;
	private float myforce;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent <BoxCollider2D> ();
		rigidBody = GetComponent <Rigidbody2D> ();
	}

	public void rotating (float rotval)
	{
		rigidBody.rotation += rotval;
	}
	
	public void moving (float dir, float offset)
	{
		if(dir == 1)
			rigidBody.AddRelativeForce (new Vector2 (offset, dir) * myforce);
		else
			rigidBody.AddRelativeForce (new Vector2 (offset, dir) * myforce * 0.8f);

		this.transform.parent.gameObject.transform.position = this.transform.position;
		this.transform.localPosition = new Vector2 (0, 0);
	}
	
	public void stopMoving ()
	{
		rigidBody.velocity = Vector2.zero;
		this.transform.localPosition = new Vector2 (0, 0);
	}

	public void GotSomething (Collider2D something)
	{
		if (something.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.entersCarryArea (something);
		
		if (something.transform.gameObject.name.Equals ("Wall"))
			gc.wallIsBlocking ();
	}

	public void LostSomething (Collider2D something)
	{
		if(something.transform.parent.gameObject.name.StartsWith("Lawyer"))
			gc.leavesCarryArea (something);
		
		if (something.transform.gameObject.name.Equals ("Wall"))
			gc.wallStoppedBlocking ();
	}

	public float getRotation()
	{
		return rigidBody.rotation + 90;;
	}

	public void setMyForce(float force)
	{
		myforce = force;
	}
	
	public void thisWasUnfortunate ()
	{
		rigidBody.AddForce (Vector2.right * 100, ForceMode2D.Impulse);
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
