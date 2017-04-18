using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

	[SerializeField] int bullet = 30;
	[SerializeField] int bullet_box = 150;
	[SerializeField] int bullet_max = 30;
	[SerializeField] float cool_time = 0.2f;
	[SerializeField] GameObject Character;
	[SerializeField] Transform HeadMarker;
	[SerializeField] Transform HeadMarkerEdge;
	// HeadMarkerEdge is null object and on the edge of the most outside circle.
	[SerializeField] GameManager gameManager;
	[SerializeField] AudioClip fire_sound;
	[SerializeField] AudioClip reload_sound;
	float HeadMarkerRadius;
	float down_length = 1.2f; 
	float timer = 0.0f;
	[SerializeField] GameObject fire_effect;
	AudioSource audioSource;
	LineRenderer line;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		line = GetComponent<LineRenderer> ();
		HeadMarkerRadius = (HeadMarker.position - HeadMarkerEdge.position).magnitude;
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown (0) && bullet > 0 && timer > cool_time) {
			Fire ();
		}
		if (Input.GetKeyDown (KeyCode.R) && bullet < bullet_max && bullet_box > 0) {
			Reload ();
		}
		timer += Time.deltaTime;
	}

	void Fire(){
		bullet--;
		timer = 0f;
		audioSource.PlayOneShot (fire_sound);
		GameObject fire_effect_instance = Instantiate(fire_effect,transform);
		fire_effect_instance.transform.localPosition = Vector3.zero;
		Vector3 fire_point;
		if (Character.GetComponent<Animator> ().GetBool ("IsCrunching")) {
			fire_point = transform.position - new Vector3(0,down_length,0);
		}else{
			fire_point = transform.position;
		}
		line.SetPosition (0,fire_point);
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
		Vector3 hit_point;
		Ray ray_from_camera = Camera.main.ScreenPointToRay (new Vector3 (screenWidth / 2.0f, screenHeight / 2.0f, 0f));
		RaycastHit hit_from_camera;
		if (Physics.Raycast (ray_from_camera, out hit_from_camera)) {
			hit_point = hit_from_camera.point;
		} else {
			hit_point = Camera.main.transform.position + ray_from_camera.direction * 100f;
		}
		Ray ray = new Ray (fire_point,hit_point-fire_point);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			line.SetPosition (1, hit.point);
			GameObject fire_effect_instance_hit = Instantiate(fire_effect,hit.point - transform.forward * 0.2f,Quaternion.identity);
			Destroy (fire_effect_instance_hit, 1.0f);
			if (hit.collider.tag == "Target" && !hit.transform.parent.GetComponent<Animator>().GetBool("IsDowned")) {
				hit.transform.parent.GetComponent<TargetController> ().ApplyDamage ();
				gameManager.AddScore (CalculateScore(hit.point));
			}
		} else {
			line.SetPosition (1, hit_point);
		}
		line.enabled = true;
		Invoke ("disableLine", 0.05f);			
		Destroy (fire_effect_instance, 1.0f);
	}

	void disableLine(){
		line.enabled = false;
	}

	void Reload(){
		int shortage = bullet_max - bullet;
		if (shortage <= bullet_box) {
			bullet_box -= shortage;
			bullet += shortage;
		} else {
			bullet += bullet_box;
			bullet_box = 0;
		}
		audioSource.PlayOneShot (reload_sound);
	}

	float CalculateScore(Vector3 pos){
		//if hit position == the center of the circle, return 100 points.
		//else if hit position == outside of the circlu, return 0 point.
		float hitDistance = (pos - HeadMarker.position).magnitude;
		if (hitDistance > HeadMarkerRadius) {
			return 0f;
		} else {
			return (HeadMarkerRadius - hitDistance) / HeadMarkerRadius * 100f;
		}
	}

	public int GetBullet(){
		return bullet;
	}

	public int GetBulletBox(){
		return bullet_box;
	}
}
