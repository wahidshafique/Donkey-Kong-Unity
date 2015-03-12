using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.Translate(Vector3.right * 1f * Time.deltaTime);

	}

	
	// Update is called once per frame
	void Update () {
	}
}
