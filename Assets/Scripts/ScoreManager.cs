using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	float score = 0f;

	public float CalculateScore(Vector3 pos,GameObject target){
		//if hit position == the center of the circle, return 100 points.
		//else if hit position == outside of the circlu, return 0 point.
		Transform HeadMarker = target.transform.parent.Find("HeadMarker");
		Transform HeadMarkerEdge = target.transform.parent.Find("HeadMarkerEdge");
		float HeadMarkerRadius = (HeadMarker.position - HeadMarkerEdge.position).magnitude;
		float hitDistance = (pos - HeadMarker.position).magnitude;
		if (hitDistance > HeadMarkerRadius) {
			return 0f;
		} else {
			return (HeadMarkerRadius - hitDistance) / HeadMarkerRadius * 100f;
		}
	}

	public void AddScore(float point){
		score += point;
	}

	public float GetScore(){
		return score;
	}

}
