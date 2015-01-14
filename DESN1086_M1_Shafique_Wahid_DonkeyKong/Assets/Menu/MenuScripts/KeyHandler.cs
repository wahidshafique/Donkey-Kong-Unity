using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return)){
			Application.LoadLevel(1);
		};

		if (Input.GetKeyDown (KeyCode.DownArrow)){
			transform.position = new Vector3(-1.815f, -0.78f, 0);
		 //if (Input.GetKeyDown (KeyCode.DownArrow)){
		//	transform.position = new Vector3(-1.815f, -1.22f, 0);
		//}
	}
}
}