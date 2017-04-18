using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField] Text timerText;
	[SerializeField] Text ScoreText;
	[SerializeField] Text BulletBoxText;
	[SerializeField] Text BulletText;
	[SerializeField] GameManager gameManager;
	[SerializeField] GunManager gunManager;

	void Start () {
		gameManager = GetComponent<GameManager> ();
	}
	
	
	void Update () {
		timerText.text = "Time: " +(gameManager.GetTime ()).ToString("N1");
		ScoreText.text = "Pt: " + gameManager.GetScore ().ToString ("N0");
		BulletBoxText.text = "BulletBox: " + gunManager.GetBulletBox().ToString ();
		BulletText.text = "Bullet: " + gunManager.GetBullet().ToString ();
	}

}
