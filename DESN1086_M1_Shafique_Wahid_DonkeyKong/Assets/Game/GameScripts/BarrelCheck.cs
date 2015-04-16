using UnityEngine;
using System.Collections;

public class BarrelCheck : MonoBehaviour {
	public AudioSource jumpBarrel; 
	public GameObject contextScore; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Barrel") {
			GameObject tempTextBox = Instantiate (this.contextScore) as GameObject;
			tempTextBox.transform.position = this.transform.position;
			
			TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();
			theText.text = "100";
			PlayerData.Instance.Score += 100;
			jumpBarrel.Play();
		}

	}
}
