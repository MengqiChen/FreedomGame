using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			gameObject.transform.position = target.position;
			transform.Rotate(Vector3.forward);
		}
	}
}
