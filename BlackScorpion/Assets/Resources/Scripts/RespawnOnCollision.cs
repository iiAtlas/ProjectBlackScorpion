using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	void OnTriggerEnter() {
		PlayerManager.instance.respawn();	
	}
}
