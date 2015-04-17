using UnityEngine;
using System.Collections;

public class DKAnimationControl : MonoBehaviour {
	public GameObject platform1;
	public GameObject platform1Cover;
	public GameObject staticLadders;
	private float waitPeriod = 3f;

	// Use this for initialization
	void Start () {
		platform1.GetComponent<Renderer>().enabled = false;
		platform1Cover.GetComponent<Renderer>().enabled = false;
		staticLadders.SetActive(false);
		for (int i = 0; i <= 5; i++){
			StartCoroutine(platformDestroyer(i));
		}
//		StartCoroutine(platformDestroyer(1));
//		StartCoroutine(platformDestroyer(2));
//		StartCoroutine(platformDestroyer(3));
//		StartCoroutine(platformDestroyer(4));
//		StartCoroutine(platformDestroyer(5));
		}

	// Update is called once per frame
	void Update () {

	
	}

	IEnumerator platformDestroyer (int index){
		yield return new WaitForSeconds(waitPeriod);
		GameObject blots = GameObject.Find("blot " + index);
		GameObject plats = GameObject.Find("StagePlatform " + index);
		//yield return new WaitForSeconds(waitPeriod);
		blots.SetActive(false);
		plats.SetActive(false);
		}
	}
