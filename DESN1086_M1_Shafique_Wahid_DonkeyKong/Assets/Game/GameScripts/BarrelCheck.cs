using UnityEngine;
using System.Collections;

public class BarrelCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Barrel")
			PlayerData.Instance.Score += 100;
	}
}
