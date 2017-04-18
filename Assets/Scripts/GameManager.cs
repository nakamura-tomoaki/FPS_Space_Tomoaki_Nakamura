using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	float score = 0.0f;
	float timer = 0.0f;
	int screenWidth;
	int screenHeight;

	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}	
	
	void Update () {
		timer += Time.deltaTime;	
	}

	public void AddScore(float point){
		score += point;
	}

	public float GetScore(){
		return score;
	}

	public float GetTime(){
		return timer;
	}
}
