using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnipeController : MonoBehaviour {

	[SerializeField] Image snipe ;
	[SerializeField] Color color_snipe;
	[SerializeField] Color color_default;
	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			print (1);
			Camera.main.fieldOfView = 11.5f;
			snipe.color = color_snipe;
		} 
		if (Input.GetMouseButtonUp (1)) {
			print (2);
			Camera.main.fieldOfView = 60f;
			snipe.color = color_default;
		}
	}
}
