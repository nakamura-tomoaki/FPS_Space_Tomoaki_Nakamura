using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS_Controller = UnityStandardAssets.Characters.FirstPerson.FirstPersonController;

public class PlayerController : MonoBehaviour {
	Animator anim;
	string crunch_param = "IsCrunching";
	GameObject character;
	public float crunching_walk_speed = 2.0f;
	float default_walk_speed;
	//FPS_Controller fps_Controller;

	void Start () {
		character = transform.FindChild ("Character").gameObject;
		if(character != null){
			anim = character.GetComponent<Animator> ();
		}
		//fps_Controller = GetComponent<FPS_Controller> ();
		//default_walk_speed = fps_Controller.m_WalkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			anim.SetBool (crunch_param, true);
			//fps_Controller.m_WalkSpeed = crunching_walk_speed;
		}
		if(Input.GetKeyUp(KeyCode.C)){
			anim.SetBool (crunch_param, false);
			//fps_Controller.m_WalkSpeed = default_walk_speed;
		}
			
	}
}
