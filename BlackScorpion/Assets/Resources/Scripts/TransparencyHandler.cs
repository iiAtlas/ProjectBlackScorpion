using UnityEngine;
using System.Collections;

public class TransparencyHandler : MonoBehaviour {
	
	public Material matSolid, matTransparent;
	public bool startTransparent = true;
	
	private bool transparent = true;
	
	void Start() {
		if(startTransparent) makeTransparent();
		else makeSolid();
	}
	
	public void toggleState() {
		if(transparent) makeSolid();
		else makeTransparent();
	}
	
	public void makeTransparent() {
		renderer.material = matTransparent;
		collider.isTrigger = true;
	}
	
	public void makeSolid() {
		renderer.material = matSolid;
		collider.isTrigger = false;
	}
}
