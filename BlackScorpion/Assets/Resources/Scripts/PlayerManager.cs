using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;
	void Awake () { instance = this; }
	
	public GameObject playerPrefab, spawn;
	
	
	public void respawn() {
		if(GameObject.FindGameObjectWithTag("Player")) Destroy(GameObject.FindGameObjectWithTag("Player"));
		GameObject obj = Instantiate(playerPrefab) as GameObject;
		obj.transform.position = spawn.transform.position;
		obj.transform.rotation = spawn.transform.rotation;
	}
}
