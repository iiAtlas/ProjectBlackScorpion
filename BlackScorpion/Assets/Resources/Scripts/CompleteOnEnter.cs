using UnityEngine;
using System.Collections;

public class CompleteOnEnter : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") LevelManager.instance.completeLevel();
	}
}
