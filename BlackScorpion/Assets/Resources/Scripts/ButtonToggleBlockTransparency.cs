using UnityEngine;
using System.Collections;

public class ButtonToggleBlockTransparency : MonoBehaviour {
	
	public GameObject[] objsToToggle;
	public bool persistent = false;
	public float toggleTime = 1.5f;
	
	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "Rock"){ 
			animation.Play("down");
			Destroy(collision.gameObject);
			foreach(GameObject obj in objsToToggle) { obj.GetComponent<TransparencyHandler>().makeSolid(); }
			StartCoroutine("pressCountdown");
		}
	}
	
	private IEnumerator pressCountdown() {
		yield return new WaitForSeconds(toggleTime);
		if(!persistent) foreach(GameObject obj in objsToToggle) { obj.GetComponent<TransparencyHandler>().makeTransparent(); }
		animation.Play("up");
	}
}
