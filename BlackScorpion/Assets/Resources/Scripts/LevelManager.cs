using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public static LevelManager instance;
	void Awake() { instance = this; }
	
	public bool complete = false;
	private float time = 0;
	
	
	void Update() {
		Debug.Log(time);
		if(!complete) time += Time.deltaTime;
	}
	
	void OnGUI() {
		if(complete) {
			Screen.lockCursor = false;
			
			GUILayout.BeginArea(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), new GUIStyle("Box"));
			GUILayout.Label("Level " + Application.loadedLevel + " Complete!");
			GUILayout.Label("Time: " + time);
			if(GUILayout.Button("Next Level")) {
				Application.LoadLevel(Application.loadedLevel + 1);
			}
			GUILayout.EndArea();
		}
	}
	
	public void completeLevel() {
		complete = true;
	}
}
