using UnityEngine;
using System.Collections;

public class ScreenEdgeController : MonoBehaviour {

	public Camera cam;
	public float initialZoom = 2;
	public float subsequentZoom = 1;
	public float maxZoom = 5;
	public GameObject secondBarrier, thirdBarrier, fourthBarrier;

	private int level = 1;
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
		if((transform.position.x <= leftBorder) && rbody.velocity.x < 0){
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

	public void ZoomOut() {
		if (cam.orthographicSize < maxZoom) {
			level++;
			if (level == 2) {
				cam.orthographicSize += initialZoom;
				gameObject.GetComponent<TrailRenderer>().enabled = true;
				secondBarrier.GetComponent<FadeObjectInOut>().enabled = true;
			} else if (level == 3) {
				cam.orthographicSize += subsequentZoom;
				thirdBarrier.GetComponent<FadeObjectInOut>().enabled = true;
			} else if (level == 4) {
				cam.orthographicSize += subsequentZoom;
				fourthBarrier.GetComponent<FadeObjectInOut>().enabled = true;
				cam.transform.SetParent(gameObject.transform);
				Vector3 playerPos = new Vector3(gameObject.transform.position.x,
				                                gameObject.transform.position.y,
				                                cam.transform.position.z);
				cam.transform.position = playerPos;
				gameObject.GetComponent<MovementController>().maxSpeed++;
			}
			dist = (transform.position - cam.transform.position).z;
			leftBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
			rightBorder = cam.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
			topBorder = cam.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;
			bottomBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		}
	}
}
