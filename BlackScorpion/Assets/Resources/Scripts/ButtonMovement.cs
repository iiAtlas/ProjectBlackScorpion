using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {

	public GameObject[] objsToToggle;
	public bool persistent = false;
	public float toggleTime = 1.5f;
	
	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "Player"){ 
			animation.Play("down");
			foreach(GameObject obj in objsToToggle) { obj.GetComponent<PingPongCube>().start(); }
			StartCoroutine("pressCountdown");
		}
	}
	
	private IEnumerator pressCountdown() {
		yield return new WaitForSeconds(toggleTime);
		if(!persistent) foreach(GameObject obj in objsToToggle) { obj.GetComponent<PingPongCube>().stop(); }
		animation.Play("up");
	}
}
