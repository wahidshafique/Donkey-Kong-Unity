using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {
	Animator Anim;

	private bool MarioFacingRight=true;
	private bool Grounded = false;
	private bool Ladder = false;
	private bool MoveCheck = true;
	private float GroundRad = 0.2f;
	private float Move;

	public float MaximumSpeed=10f;
	public float JumpForce = 700f;
	public Transform GroundCheck;
	public LayerMask WhatIsGround;
	
	//TODO: when ground is false then you cannot press up arbitrariliy 
	void Start () {
		Anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		Move = Input.GetAxis ("Horizontal");

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRad, WhatIsGround);
		Anim.SetBool ("Ground", Grounded);

		Anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);

		if (MoveCheck){
		Anim.SetFloat("Speed", Mathf.Abs(Move));
		rigidbody2D.velocity = new Vector2 (Move * MaximumSpeed, rigidbody2D.velocity.y);
		if (Move > 0 && !MarioFacingRight)
			Flipper();
			else if (Move<0 && MarioFacingRight)
				Flipper();
		}
	}

	void OnTriggerStay2D(Collider2D other){
		print("hello");
		//rigidbody2D.velocity = new Vector2 (0,0);
		if (Grounded){
		Ladder = true;
		//MoveCheck=false;
			Move=0;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		Ladder = false;
		}
	
	void Update(){
		if (Anim.GetBool("Ladder") == false && Grounded && Input.GetKeyDown(KeyCode.Space)){
			Anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,JumpForce));
		}

		//TODO: 

		if (Ladder && Input.GetAxis ("Vertical")>0 && Grounded){
			Anim.SetBool("Ladder", Ladder);
			transform.Translate (new Vector2(0, 0.2f)* Time.deltaTime*MaximumSpeed);
			rigidbody2D.gravityScale=0;
		} else if (!Ladder) {
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
 
