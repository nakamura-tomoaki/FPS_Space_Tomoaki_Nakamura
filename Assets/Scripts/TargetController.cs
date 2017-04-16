using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {
	[SerializeField] int hp = 5;
	Animator anim;
	float timer = 0.0f;
	string isDowned = "IsDowned";

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 10.0f && anim.GetBool(isDowned)) {
			anim.SetBool (isDowned, false);
			hp = 5;
		}
	}

	public void ApplyDamage(){
		hp--;
		if (hp <= 0) {
			anim.SetBool (isDowned, true);
			timer = 0f;
		}
	}
}
