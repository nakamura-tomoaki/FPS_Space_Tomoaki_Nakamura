using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

	[SerializeField] int bullet = 30;
	[SerializeField] int bullet_box = 150;
	[SerializeField] float cool_time = 0.5f;
	float timer = 0.0f;

	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown (0) && bullet > 0 && timer > cool_time) {
			Fire ();
		}

		timer += Time.deltaTime;

	}

	void Fire(){
		print("Fire!!");
		bullet--;
		timer = 0f;
	}
}
