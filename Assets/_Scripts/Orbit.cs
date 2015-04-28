using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	private GameObject gameController;
	private GameObject parent;
	private bool collected;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		parent = gameObject.transform.parent.gameObject;
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			parent.GetComponent<Follow> ().target = other.gameObject.transform;
			if (other.gameObject.GetComponent<MovementController>().playerOne) {
				gameController.GetComponent<GameController>().IncreaseScore(0, 1000);
			} else {
				gameController.GetComponent<GameController>().IncreaseScore(1, 1000);
			}
			sound.Play();
		}
	}
}
