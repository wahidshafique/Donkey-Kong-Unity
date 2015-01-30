using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {
	private bool initial=true;

	// Use this for initialization
	//void EnterKey (int take){
		//if (Input.GetKey(KeyCode.Return)){
		//	Application.LoadLevel(take);
		//	print("load");
	//	};
//	}
	
	void Update () {
		if (initial){
			if (Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel(1);}
		if (Input.GetKeyDown (KeyCode.DownArrow)){
			transform.position = new Vector2(-1.815f, -0.78f);
			initial=false;
		} 
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag=="2"){
			if (Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevel(2);}
			 if (Input.GetKeyDown (KeyCode.UpArrow)){
			transform.position = new Vector2(-1.815f, -0.326f);
				initial=true;}
				 if (Input.GetKeyDown (KeyCode.DownArrow)){
					transform.position = new Vector2(-1.815f, -1.24f);
				}
			}
	}
}
