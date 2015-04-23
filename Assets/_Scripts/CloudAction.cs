﻿using UnityEngine;
using System.Collections;

public class CloudAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Cloud") {
			other.gameObject.GetComponent<AudioSource>().Play();
			SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();
			GetComponent<TrailRenderer>().material.SetColor("_TintColor", renderer.color);
		}
	}
}