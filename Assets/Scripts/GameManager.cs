using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField] float timer = 90.0f;

	void Start () {
	}	
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0f) {
			timer = 0f;
		}
	}

	public float GetTime(){
		return timer;
	}
}
