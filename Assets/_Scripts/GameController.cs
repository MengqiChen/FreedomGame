using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private float p1Score = 0;
	private float p2Score = 0;
	public int p1Followers = 0;
	public int p2Followers = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseScore(int player, float score) {
		if (player == 0) {
			p1Score += score;
		} else {
			p2Score += score;
		}
	}

	public void GameOver() {
		if (p1Score > p2Score) {
			Application.LoadLevel ("Player1Win");
		} else {
			Application.LoadLevel ("Player2Win");
		}
	}
}
