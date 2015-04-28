using UnityEngine;
using System.Collections;

public class BalloonAction : MonoBehaviour {

	public float bobDistance = 0.5f;

	private Renderer rend;
	private AudioSource sound;
	private Animator anim;
	private Collider2D coll;
	private bool up = false;
	private bool isPopped = false;
	private Vector2 origPos, bobPos;
	private GameObject clone;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		anim = GetComponent<Animator> ();
		anim.Play ("IdleBalloon");
		coll = GetComponent<Collider2D> ();
		coll.enabled = true;
		origPos = transform.position;
		bobPos = new Vector3 (origPos.x, origPos.y + bobDistance);
		sound = GetComponent<AudioSource> ();
		clone = gameObject;
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPopped) {
			bobBalloon();
		}
	}

	private void bobBalloon() {
		if (up) {
			if (transform.position.y >= origPos.y) {
				transform.position = new Vector2 (transform.position.x,
				                                 transform.position.y - 0.005f);
			} else {
				up = false;
			}
		} else {
			if (transform.position.y <= bobPos.y) {
				transform.position = new Vector2 (transform.position.x, 
				                                  transform.position.y + 0.005f);
			} else {
				up = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && GetComponent<FadeObjectInOut>().done) {
			anim.Play ("Pop");
			isPopped = true;
			coll.enabled = false;
			if (other.gameObject.GetComponent<MovementController>().playerOne) {
				gameController.GetComponent<GameController>().IncreaseScore(0, 500);
			} else {
				gameController.GetComponent<GameController>().IncreaseScore(1, 500);
			}
			Invoke("Cleanup", 1);
			Invoke ("Respawn", 3);
		}
	}

	void Cleanup() {
		rend.enabled = false;
		anim.Play ("IdleBalloon");
	}

	void Respawn() {
		clone.GetComponent<Renderer> ().enabled = false;
		Instantiate (clone, origPos, transform.rotation);
	}

	void PlaySound() {
		sound.Play ();
	}
}
