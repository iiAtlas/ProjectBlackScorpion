using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") Application.LoadLevel(Application.loadedLevel);
	}
}
