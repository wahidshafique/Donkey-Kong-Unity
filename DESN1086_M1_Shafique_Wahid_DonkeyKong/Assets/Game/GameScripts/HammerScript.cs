using UnityEngine;
using System.Collections;

public class HammerScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") Destroy(gameObject);
	}
}
