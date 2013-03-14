using UnityEngine;
using System.Collections;

public class ButtonToggleBlockTransparency : MonoBehaviour {
	
	public GameObject objToToggle;
	public bool persistent = false;
	public float toggleTime = 1.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "Player"){ 
			animation.Play("down");
			objToToggle.GetComponent<TransparencyHandler>().makeSolid();
			StartCoroutine("pressCountdown");
		}
	}
	
	private IEnumerator pressCountdown() {
		yield return new WaitForSeconds(toggleTime);
		if(!persistent) objToToggle.GetComponent<TransparencyHandler>().makeTransparent();
		animation.Play("up");
	}
}
