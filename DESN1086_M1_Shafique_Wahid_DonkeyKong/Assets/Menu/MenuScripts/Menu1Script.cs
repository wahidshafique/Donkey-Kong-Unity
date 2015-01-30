using UnityEngine;
using System.Collections;

public class Menu1Script : MonoBehaviour {
	
	void Update () {
		if (Input.GetKey(KeyCode.Return))
			Application.LoadLevel("Help2");
	}
}
