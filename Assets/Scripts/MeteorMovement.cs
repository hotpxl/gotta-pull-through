using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour {

	[SerializeField]private float x;
	[SerializeField]private float y;
	[SerializeField]private float t;

	// Use this for initialization
	void Start () {
		if (x != 0 || y != 0)
			iTween.MoveBy (gameObject, iTween.Hash("x", x, "y", y, "easeType", iTween.EaseType.easeInOutQuad, "loopType", iTween.LoopType.pingPong, "delay", 0.0, "time", t));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
