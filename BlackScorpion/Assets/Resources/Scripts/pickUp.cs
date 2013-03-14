using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {
	
	int rockCount;
	public Texture2D crosshairTexture;
	public Camera camera;
	public GameObject rock;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = camera.ScreenPointToRay(new Vector3((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) /2,0));
		RaycastHit hit; 
		
		if (Physics.Raycast(ray, out hit)) {
			if(hit.collider.gameObject.tag == "Rock"){
				Debug.Log("Press E to Pick up Rock");
				//hit.collider.gameObject.renderer.material.color = Color.red;
				if(Input.GetKeyDown(KeyCode.E)){
	    			Destroy(hit.collider.gameObject);
					rockCount ++;
					Debug.Log("You now have " + rockCount + " rocks.");
				}
			}
		}
		
        if(Input.GetMouseButtonDown(0)){
			if(rockCount > 0){
				rockCount --;
				Debug.Log("Rock Placed. You now have " + rockCount + " rocks.");
				Instantiate(rock, hit.point + new Vector3(0,0.1f,0),Quaternion.identity);
			}
		}
	}
}
