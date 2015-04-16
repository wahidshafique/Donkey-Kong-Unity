using UnityEngine;
using System.Collections;

public class TextHolderHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		StartCoroutine(breaker());
	}
	IEnumerator breaker(){
		yield return new WaitForSeconds(0.3f);
		Destroy(this.gameObject);
	}
}
