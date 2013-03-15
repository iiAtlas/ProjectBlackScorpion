using UnityEngine;
using System.Collections;

public class GameCompleteScreen : MonoBehaviour {
	
	public TextMesh scoreMesh, deathsMesh;
	
	// Use this for initialization
	void Start () {
		scoreMesh.text = "Score: " + GameManager.instance.getScore();
		deathsMesh.text = "Deaths: " + GameManager.instance.deaths;
	}
}
