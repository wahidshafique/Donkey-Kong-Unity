using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {

	// Use this for initialization
    //bool CanMove=true; 
	public float MaximumSpeed=10f;
	bool MarioFacingRight=true;
	Animator Anim;
	
	bool Grounded = false;
	bool Ladder = false;
	public Transform GroundCheck;
	float GroundRad = 0.2f;
	public LayerMask WhatIsGround;
	public float JumpForce = 700f;

	void Start () {
		Anim = GetComponent<Animator>();
	}

	void FixedUpdate () {

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRad, WhatIsGround);
		Anim.SetBool ("Ground", Grounded);

		Anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);

		 float Move;
		//if (CanMove){
			//CanMove=true;
			Move = Input.GetAxis ("Horizontal");

		Anim.SetFloat("Speed", Mathf.Abs(Move));

		rigidbody2D.velocity = new Vector2 (Move * MaximumSpeed, rigidbody2D.velocity.y);
		//this.transform.position.y = this.transform.position.y-0.05;
		if (Move > 0 && !MarioFacingRight)
			Flipper();
			else if (Move<0 && MarioFacingRight)
				Flipper();
		}

	void OnTriggerStay2D(Collider2D other){
		print("hello");
		Ladder = true;}

	//var Ladder
	void Update(){
		if (Grounded && Input.GetKeyDown(KeyCode.Space)){
			Anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,JumpForce));
			}

		if (Ladder && Input.GetAxis ("Vertical")>0){
			Anim.SetBool("Ladder", Ladder);
			transform.Translate (new Vector2(0, 0.2f)* Time.deltaTime*MaximumSpeed);
			rigidbody2D.gravityScale=0;
		} if (!Ladder) {
			Anim.SetBool("Ladder",Ladder);
			rigidbody2D.gravityScale=1;}
		}

	void Flipper (){

		MarioFacingRight = !MarioFacingRight;

		Vector3 TheScale = transform.localScale;

		TheScale.x *= -1;

		transform.localScale = TheScale;
	}




		
}
 
