using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

	[SerializeField] int bullet = 30;
	[SerializeField] int bullet_box = 150;
	[SerializeField] float cool_time = 0.2f;
	float timer = 0.0f;
	GameObject fire_effect;
	AudioSource audioSource;
	LineRenderer line;

	void Start () {
		fire_effect = Resources.Load<GameObject> ("Fire_effect");
		audioSource = GetComponent<AudioSource> ();
		line = GetComponent<LineRenderer> ();
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
		GameObject fire_effect_instance = Instantiate(fire_effect,transform.position,transform.rotation);
		Destroy (fire_effect_instance, 1.0f);
		audioSource.Play ();
		line.enabled = true;
		line.SetPosition (0, transform.position);
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			line.SetPosition (1, hit.point);
		} else {
			line.SetPosition (1, transform.position + transform.forward * 100f);
		}
		Invoke ("disableLine", 0.05f);			
	}

	void disableLine(){
		line.enabled = false;
	}
}
