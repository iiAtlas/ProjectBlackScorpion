using UnityEngine;
using System.Collections;

public class PingPongCube : MonoBehaviour {
	
	public GameObject endPos;
	public float time = 5, delay;
	public bool autoRun = true;
	
	private bool running = false;
	private float id;
	
	void Start() {
		id = Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		if(autoRun) {
			if(!running) {
				running = true;
				iTween.MoveTo(gameObject, iTween.Hash("name", id.ToString(), "time", time, "position", endPos.transform.position, "easeType", "linear", "loopType", "pingPong", "delay", delay));
			}
		}
	}
	
	public void start() {
		iTween.MoveTo(gameObject, iTween.Hash("name", id.ToString(), "time", time, "position", endPos.transform.position, "easeType", "linear", "loopType", "pingPong", "delay", delay));
	}
	
	public void stop() {
		iTween.StopByName(id.ToString());
	}
}
