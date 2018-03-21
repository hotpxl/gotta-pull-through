using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
	public float x;
	public float y;
	public float t;

	void Start ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("x", x, "y", y, "easeType", iTween.EaseType.easeInOutQuad, "loopType", iTween.LoopType.pingPong, "delay", 0.0, "time", t));
	}
}
