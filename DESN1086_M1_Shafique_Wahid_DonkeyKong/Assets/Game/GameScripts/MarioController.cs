using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {
	Animator anim;

	private bool marioFacingRight=true;
	private bool grounded = false;
	private bool ladder = false;
	private bool moveCheck = true;
	private float groundRad = 0.2f;
	private float move;

	public float maximumSpeed=10f;
	public float jumpForce = 700f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	//TODO: when ground is false then you cannot press up arbitrarily 

	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("VSpeed", GetComponent<Rigidbody2D>().velocity.y);

		if (moveCheck) {
		anim.SetFloat("Speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maximumSpeed, GetComponent<Rigidbody2D>().velocity.y);
		if (move > 0 && !marioFacingRight)
			Flipper();
			else if (move<0 && marioFacingRight)
				Flipper();
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//rigidbody2D.velocity = new Vector2 (0,0);
		if (grounded && other.gameObject.tag == "ladder") {
		ladder = true;
		//moveCheck=false;
			//move=0;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "ladder") ladder = false;
		}
	
	void Update(){
		if (anim.GetBool("Ladder") == false && grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool("Ground",false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
		}

		if (ladder && Input.GetAxis ("Vertical")>0 && grounded){
			anim.SetBool("Ladder", ladder);
			transform.Translate (new Vector2(0, 0.2f)* Time.deltaTime*maximumSpeed);
			GetComponent<Rigidbody2D>().gravityScale=0;	

			if (Input.GetAxis ("Vertical") < 0)
				transform.Translate (new Vector2(0, -0.2f)* Time.deltaTime*maximumSpeed);
		} else if (!ladder) {
			anim.SetBool("Ladder",ladder);
			GetComponent<Rigidbody2D>().gravityScale=1;
			}
		}

	void Flipper (){

		marioFacingRight = !marioFacingRight;

		Vector3 TheScale = transform.localScale;

		TheScale.x *= -1;

		transform.localScale = TheScale;
	}						
}
 
