using UnityEngine;
using System.Collections;

public class PaulineScript : MonoBehaviour {
	public GameObject player;
	Animator anim; 
	public AudioSource win;
	public bool DKhaul = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		}

	void OnTriggerEnter2D(Collider2D other){
		if  (player.GetComponent<MarioController>().endGame){
			anim.SetBool("End", true);
			win.Play();
			StartCoroutine(endsec());
	}
	}
		IEnumerator endsec(){
			yield return new WaitForSeconds(2);
			DKhaul = true; 
		yield return new WaitForSeconds(1);
			this.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(2);
		Application.LoadLevel(0);

		}
}
