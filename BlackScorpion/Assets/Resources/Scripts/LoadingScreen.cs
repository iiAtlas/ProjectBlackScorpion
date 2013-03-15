using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	
	public Material hoverMat, playMat, quitMat;
	
	// Update is called once per frame
	void Update () {
		RaycastHit hoverHit;
		if(Physics.Raycast(Camera.mainCamera.ScreenPointToRay(Input.mousePosition), out hoverHit)) {
			if(hoverHit.collider.tag != "Ground") hoverHit.collider.renderer.material = hoverMat;
		}else {
			GameObject.FindGameObjectWithTag("PlayB").renderer.material = playMat;
			GameObject.FindGameObjectWithTag("QuitB").renderer.material = quitMat;
		}
		
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.mainCamera.ScreenPointToRay(Input.mousePosition), out hit)) {
				if(hit.collider.tag == "PlayB") Application.LoadLevel(Application.loadedLevel + 1);
				else if(hit.collider.tag == "QuitB") Application.Quit();
			}
		}
	}
}
