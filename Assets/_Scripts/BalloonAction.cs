using UnityEngine;
using System.Collections;

public class BalloonAction : MonoBehaviour {

	public float bobDistance = 0.5f;

	private AudioSource audio;
	private Animator anim;
	private bool up = false;
	private bool isPopped = false;
	private Vector2 origPos, bobPos;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		origPos = transform.position;
		bobPos = new Vector3 (origPos.x, origPos.y + bobDistance);
		audio = GetComponent<AudioSource> ();
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

	void OnCollisionEnter2D(Collision2D collision) {
		anim.SetTrigger ("Popped");
		isPopped = true;
		Respawn ();
		gameObject.GetComponent<Renderer> ().enabled = false;
		gameObject.SetActive (false);
		Invoke ("Respawn", 3);
	}

	void Respawn() {
		GameObject clone;
		clone = Instantiate (gameObject, origPos, transform.rotation) as GameObject;
		clone.GetComponent<Renderer> ().enabled = true;
		clone.SetActive (true);
	}

	void PlaySound() {
		audio.Play ();
	}
}
