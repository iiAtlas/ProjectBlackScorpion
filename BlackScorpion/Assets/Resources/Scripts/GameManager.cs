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

	public int getScore() { return 10000 - (Mathf.RoundToInt(totalTime) - (deaths * 10)); }
}
