using UnityEngine;
using System.Collections;

public class OilBarrelScript : MonoBehaviour {
	Transform FireSpawnPos;
	// Use this for initialization
	void Start () {
		FireSpawnPos = gameObject.transform.FindChild("FireSpawner");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Barrel"){
		GameObject fire = Instantiate(Resources.Load ("Fireball")) as GameObject;
		fire.transform.parent = transform;
		fire.transform.localPosition = FireSpawnPos.localPosition;
		fire.name = "Fire";
		}
	}
}
