using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public bool playerOne = true;
	public float maxSpeed = 10f;
	public bool facingRight = true;

	private GameObject gameController;
	private Rigidbody2D rbody;
	private Animator anim;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		sound = GetComponent<AudioSource>();
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
		float speed = Mathf.Abs (moveX) + Mathf.Abs (moveY);
		anim.SetFloat ("Speed", speed);
		rbody.velocity = new Vector2 (moveX * maxSpeed, moveY * maxSpeed);

		// score
		if (playerOne && speed > 0) {
			gameController.GetComponent<GameController> ().IncreaseScore (0, speed);
		} else if (speed > 0) {
			gameController.GetComponent<GameController> ().IncreaseScore (1, speed);
		}

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

	void PlaySound() {
		sound.Play ();
	}
}
