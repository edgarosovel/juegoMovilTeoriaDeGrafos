using UnityEngine;
using System.Collections;

public class anim_control : MonoBehaviour {

	Animator anim;
	bool doit;
	void Start () {
		anim = GetComponent<Animator> ();
		doit=false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (anim.GetBool ("do")) {
			if (doit) {
				anim.SetBool ("do", false);	
			}
			doit = true;
		} else {
			doit = false;
		}
	}
}
