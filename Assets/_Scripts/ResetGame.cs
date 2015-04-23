using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {

	public float resetDelay = 5;
	private float resetTimer;
	
	// Update is called once per frame
	void Update () {
		Reset ();
	}

	private void Reset () {
		resetTimer += Time.unscaledDeltaTime;
		if (resetTimer >= resetDelay) {
			Application.LoadLevel ("layout");
		}
	}
}
