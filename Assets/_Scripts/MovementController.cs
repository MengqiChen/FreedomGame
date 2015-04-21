using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public bool playerOne = true;
	public float maxSpeed = 10f;
	bool facingRight = true;

	private Rigidbody2D rbody;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float moveX = 0;
		float moveY = 0;
		if (playerOne) {
			moveX = Input.GetAxis ("Horizontal");
			moveY = Input.GetAxis ("Vertical");
		} else {
			moveX = Input.GetAxis ("Horizontal2");
			moveY = Input.GetAxis ("Vertical2");
		}
		anim.SetFloat ("Speed", Mathf.Abs (moveX) + Mathf.Abs(moveY));
		rbody.velocity = new Vector2 (moveX * maxSpeed, moveY * maxSpeed);

		if (moveX > 0 && !facingRight) {
			Flip ();
		} else if (moveX < 0 && facingRight) {
			Flip ();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
