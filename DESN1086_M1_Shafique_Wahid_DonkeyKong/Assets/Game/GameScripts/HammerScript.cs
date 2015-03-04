using UnityEngine;
using System.Collections;

public class HammerScript : MonoBehaviour {
	Animator anim; 

	void Start (){
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") Destroy(gameObject);
		anim.SetBool("HammerTime", true);
	}
}
