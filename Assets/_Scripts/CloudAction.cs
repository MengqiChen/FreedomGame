using UnityEngine;
using System.Collections;

public class CloudAction : MonoBehaviour {

	private GameObject gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Cloud") {
			other.gameObject.GetComponent<AudioSource>().Play();
			SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();
			GetComponent<TrailRenderer>().material.SetColor("_TintColor", renderer.color);
			if (gameObject.GetComponent<MovementController>().playerOne) {
				gameController.GetComponent<GameController>().IncreaseScore(0, 200);
			} else {
				gameController.GetComponent<GameController>().IncreaseScore(1, 200);
			}
		}
	}
}
