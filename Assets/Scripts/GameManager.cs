using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	float score = 0.0f;
	[SerializeField] float timer = 90.0f;

	void Start () {
	}	
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0f) {
			timer = 0f;
		}
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
