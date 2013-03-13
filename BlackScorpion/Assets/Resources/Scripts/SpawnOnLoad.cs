using UnityEngine;
using System.Collections;

public class SpawnOnLoad : MonoBehaviour {
	
	void Start() {
		PlayerManager.instance.respawn();
	}
}
