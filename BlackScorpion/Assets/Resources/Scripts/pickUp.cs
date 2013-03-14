using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {
	
	int rockCount;
	public Texture2D crosshairTexture;
	private Camera cam;
	public GameObject rock;
	
	// Use this for initialization
	void Start () {
		cam = Camera.mainCamera;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ScreenPointToRay(new Vector3((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) /2,0));
		RaycastHit hit; 
		
		if(Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(ray, out hit)) {
				if(hit.collider.gameObject.tag == "Rock") {
	    			Destroy(hit.collider.gameObject);
					rockCount++;
				}else throwRock();
			}else throwRock();
		}
	}
	
	private void throwRock() {
		if(rockCount > 0) {
			rockCount--;
			Ray r2 = cam.ScreenPointToRay(new Vector3((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) /2,0));
			
			GameObject rockVisible = Instantiate(rock, cam.transform.position + r2.direction, Quaternion.identity) as GameObject;
			rockVisible.rigidbody.AddForce(cam.transform.forward * 10, ForceMode.Impulse);
		}
	}
}