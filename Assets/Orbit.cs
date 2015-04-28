using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	private GameObject parent;
	private bool collected;

	// Use this for initialization
	void Start () {
		parent = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("d");
		if (other.gameObject.tag == "Player") {
			parent.GetComponent<Follow> ().target = other.gameObject.transform;
		}
	}
}
