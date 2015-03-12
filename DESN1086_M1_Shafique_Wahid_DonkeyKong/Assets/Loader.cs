using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	public bool loadLevel = false;
	public int level;

	// Use this for initialization
	void Start () {
		if (loadLevel)
			Application.LoadLevel(level);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel(0);
}
}
}
