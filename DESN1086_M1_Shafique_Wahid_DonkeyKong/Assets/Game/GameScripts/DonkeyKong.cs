using UnityEngine;
using System.Collections;

public class DonkeyKong : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D Barrel;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody clone;
		clone = Instantiate(Barrel, transform.position, transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection(Vector3.forward * 50);
	}
}
