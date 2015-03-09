using UnityEngine;
using System.Collections;

public class DKAnimationControl : MonoBehaviour {
	public GameObject platform1;
	public GameObject platform1Cover;
	public GameObject staticLadders;

	// Use this for initialization
	void Start () {
		platform1.GetComponent<Renderer>().enabled = false;
		platform1Cover.GetComponent<Renderer>().enabled = false;
		staticLadders.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
