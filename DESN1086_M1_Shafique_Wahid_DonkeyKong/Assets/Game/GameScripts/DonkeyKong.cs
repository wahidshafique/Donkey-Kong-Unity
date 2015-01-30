using UnityEngine;
using System.Collections;

public class DonkeyKong : MonoBehaviour {
	public Rigidbody2D projectile;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () { 
		Rigidbody clone; 
				clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody; 
					clone.velocity = transform.TransformDirection(Vector3.forward * 50); 


	}
}
