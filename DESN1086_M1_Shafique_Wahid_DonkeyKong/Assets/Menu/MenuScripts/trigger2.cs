using UnityEngine;
using System.Collections;

public class trigger2 : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Object in Trigger2");
		print("Object in Trigger2");
	}
	// Use this for initialization
	void Start () {
		Debug.Log("Trigger: " + collider2D.isTrigger);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
