using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {
	//commented out code for testing purposes, still not entirely functional

	Animator anim;
	new Rigidbody2D myRigidbody2D;

	private Collider2D currentFloor;

	private bool marioFacingRight=true;
	private bool grounded = false;
	private bool ladder = false;
	private bool moveCheck = true;
	private float groundRad = 0.05f;

	private bool topTouch = false; 
	private float topRad= 0.05f;

	private float move;
	private float maximumSpeed=2f;
	private float jumpForce = 150f;
	private bool canJump = true; 

	public AudioSource deathClip;
	public AudioSource jumpClip;

	public Transform groundCheck;
	public Transform topCheckObject;

	public LayerMask whatIsGround;
	public LayerMask whatIsTop;

	public GameObject flooring;

	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		topTouch = Physics2D.OverlapCircle (topCheckObject.position, topRad, whatIsTop);


		move = Input.GetAxis ("Horizontal");

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("VSpeed", myRigidbody2D.velocity.y);

		if (moveCheck) {
		anim.SetFloat("Speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maximumSpeed,myRigidbody2D.velocity.y);

		if (move > 0 && !marioFacingRight) Flipper();
			else if (move<0 && marioFacingRight) Flipper();
		}
	}
	
	void Flipper (){
		
		marioFacingRight = !marioFacingRight;
		
		Vector3 TheScale = transform.localScale;
		
		TheScale.x *= -1;
		
		transform.localScale = TheScale;
	}	
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Barrel"){
			this.gameObject.tag = "DeadPlayer";
			this.myRigidbody2D.isKinematic = true;
			anim.SetBool("Death", true);
			grounded = true;
			deathClip.Play();
			PlayerData.Instance.Health--;
		}
		if (coll.collider.gameObject.name.Contains("Floor")) {
			currentFloor = coll.collider;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//rigidbody2D.velocity = new Vector2 (0,0);
		if (grounded && other.gameObject.tag == "Ladder" ) {
			if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0) {
				canJump = false;
				ladder = true;
				anim.SetBool("Ladder",true);
			}
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Ladder") {
			ladder = false;
			canJump = true;
			anim.SetBool("Ladder",ladder);
		}
	}
	
	void Update(){
		if (!grounded && ladder) moveCheck = false;
		else moveCheck = true; 
		jump();
		LadderClimb();
	}

	void jump (){
		if (grounded && Input.GetKeyDown(KeyCode.Space) && canJump){
			jumpClip.Play();
			anim.SetBool("Ground",false);
			myRigidbody2D.AddForce(new Vector2(0,jumpForce));
		}
	}

	void LadderClimb(){

		if (ladder){
			float climbVel = 2 * Input.GetAxisRaw("Vertical");
			myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVel);
			myRigidbody2D.gravityScale=0; 
			if (topTouch) {
				Physics2D.IgnoreCollision(currentFloor, gameObject.GetComponent<Collider2D>());
				topTouch = false;
				//GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
			} 
		} else {
			myRigidbody2D.gravityScale=1;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Hammer"){
			anim.SetBool("HammerTime", true);
			StartCoroutine (timedHammer());
			this.gameObject.tag = "Hammer";
			
		}
	}
	
	IEnumerator timedHammer (){
		yield return new WaitForSeconds(5);
		anim.SetBool("HammerTime",false);
		
	}
}

 
