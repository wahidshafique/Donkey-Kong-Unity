using UnityEngine;
using System.Collections;

public class Menu2Script : MonoBehaviour {
	void Update () {
		if (Input.GetKey(KeyCode.Return))
		Application.LoadLevel("MainMenu");
	}
}
