using UnityEngine;
using System.Collections;

public class DonkeyKong : MonoBehaviour {
	public GameObject Barrel;
	private float fireRate = 2f;
	private float nextFire = 1f;
	Animator anim;


	void Start () {
		anim = GetComponentInParent<Animator>();
		StartCoroutine (barrelAnim());
	}

	void Update () {

		throwBarrel();

		}

	void throwBarrel (){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(Barrel, position, transform.rotation);
	}
	}

	IEnumerator barrelAnim (){
		while (true){
			anim.SetBool("NormalBarrel", true);
			yield return new WaitForSeconds (2f);
		}
	}
}
