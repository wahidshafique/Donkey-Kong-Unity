using UnityEngine;
using System.Collections;

public class DonkeyKong : MonoBehaviour {
	Animator anim;
	Transform barrelSpawnPos;
	public GameObject pauline;
	private bool barrel = true; 
	private bool animPlay = true;
	
	void Start () {
		
		anim = gameObject.GetComponent<Animator>();
		barrelSpawnPos = gameObject.transform.FindChild("BarrelSpitter");
		StartCoroutine(SpawnBarrel(1.0f));
	}

	void Update (){
	if(pauline.GetComponent<PaulineScript>().DKhaul && animPlay){
			anim.SetBool("End", true);
			barrel = false;
			animPlay = false;
		}
	}
	
	IEnumerator SpawnBarrel(float delay) {
		yield return new WaitForSeconds(delay);
		if (barrel){
		
		anim.SetTrigger("ThrowBarrel");
			StartCoroutine(SpawnBarrel(6.0f));
		}
	}
	
	public void ReleaseBarrel() {
		
		GameObject barrel = Instantiate(Resources.Load ("BarrelPrefab")) as GameObject;
		barrel.transform.parent = transform;
		barrel.transform.localPosition = barrelSpawnPos.localPosition;
		barrel.name = "Barrel";
	}
	
	public void Stop() {
		anim.StopPlayback();
		Destroy (this);
	}
}
