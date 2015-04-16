using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
		}
	}