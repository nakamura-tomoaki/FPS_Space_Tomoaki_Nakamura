using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	float score = 0.0f;
	float timer = 0.0f;

	void Start () {
		
	}
	
	
	void Update () {
		timer += Time.deltaTime;	
	}

	public void AddScore(float point){
		score += point;
		print ("Score: " + score.ToString ());
	}

	public float GetScore(){
		return score;
	}

	public float GetTime(){
		return timer;
	}
}
