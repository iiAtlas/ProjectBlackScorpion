using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	void Awake() { instance = this; DontDestroyOnLoad(gameObject); }
	
	private float totalTime;
	public int deaths;
	
	void OnGUI() {
		GUI.Box(new Rect(20, 20, 100, 30), "", new GUIStyle("Box"));
		GUI.Label(new Rect(30, 25, 750, 25), "Deaths: " + deaths);
	}
	
	public void appendTime(float newTime) { totalTime += newTime; }
	
	public void completeGame() {
		int score = 10000 - (Mathf.RoundToInt(totalTime) - (deaths * 10));
		
		GUILayout.BeginArea(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), new GUIStyle("Box"));
		GUILayout.Label("Game Complete!");
		GUILayout.Label("Score: " + score);
		if(GUILayout.Button("Quit")) Application.Quit();
		GUILayout.EndArea();
	}
}
