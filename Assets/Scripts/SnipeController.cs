using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeController : MonoBehaviour {

	[SerializeField] Animator camera_anim;
	[SerializeField] Animator snipe_sprite_anim;
	string IsSniping = "IsSniping";
	void Start () {
		
	}
	
	
	void Update () {
		camera_anim.SetBool (IsSniping, Input.GetMouseButton(1));
		snipe_sprite_anim.SetBool (IsSniping, Input.GetMouseButton(1));
	}
}
