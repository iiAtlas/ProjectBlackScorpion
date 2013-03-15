using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			GameManager.instance.deaths++;
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
