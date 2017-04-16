using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	float score = 0.0f;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

	public void AddScore(float point){
		score += point;
		print ("Score: " + score.ToString ());
	}
}
