using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float time;

	void Update () {
		
		time -= Time.deltaTime;
		
		//int minutes = (int) time / 60;
		//int seconds = (int) time % 60;
		//float fraction = Mathf.Round((time * 100) % 100);
		
		if (time <= 0) {
			GetComponent<GameController>().GameOver();
		}
		
	}

	public float GetTime() {
		return time;
	}
}
