using UnityEngine;
using System.Collections;

public class buttonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "rock"){ 
			animation.Play("down");
		}
	}
	void OnTriggerExit(Collider collision) {
		if(collision.gameObject.tag == "rock"){
			animation.Play("up");
		}
	}
	
}
