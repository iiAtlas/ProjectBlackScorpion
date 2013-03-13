using UnityEngine;
using System.Collections;

public class PingPongCube : MonoBehaviour {
	
	public GameObject endPos;
	public float time, delay;
	
	private bool running = false;
	
	// Update is called once per frame
	void Update () {
		if(!running) {
			running = true;
			iTween.MoveTo(gameObject, iTween.Hash("time", time, "position", endPos.transform.position, "easeType", "linear", "loopType", "pingPong", "delay", delay));
		}
	}
}
