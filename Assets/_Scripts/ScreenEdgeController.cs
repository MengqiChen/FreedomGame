using UnityEngine;
using System.Collections;

public class ScreenEdgeController : MonoBehaviour {

	public Camera cam;
	private float dist, leftBorder, rightBorder, topBorder, bottomBorder;
	private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		dist = (transform.position - cam.transform.position).z;
		leftBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		rightBorder = cam.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		topBorder = cam.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;
		bottomBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position.x <= leftBorder) && rbody.velocity.x < 0f){
			ZoomOut();
		}
		
		if((transform.position.x >= rightBorder) && rbody.velocity.x > 0){
			ZoomOut();
		}
		
		if((transform.position.y <= bottomBorder) && rbody.velocity.y < 0){
			ZoomOut();
		}
		
		if((transform.position.y >= topBorder) && rbody.velocity.y > 0){
			ZoomOut();
		}
	}

	void ZoomOut() {
		if (cam.orthographicSize <= 6) {
			cam.orthographicSize += 2;
			dist = (transform.position - cam.transform.position).z;
			leftBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
			rightBorder = cam.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
			topBorder = cam.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;
			bottomBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		}
	}
}
