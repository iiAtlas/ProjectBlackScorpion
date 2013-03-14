using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	void OnTriggerEnter() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
