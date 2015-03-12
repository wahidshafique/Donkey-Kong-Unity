using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {
	//commented out code for testing purposes, still not entirely functional

	Animator anim;
	new Rigidbody2D rigidbody2D;

	private bool marioFacingRight=true;
	private bool grounded = false;
	private bool ladder = false;
	private bool moveCheck = true;
	private float groundRad = 0.2f;
	private float move;
	private float maximumSpeed=2f;
	private float jumpForce = 150f;

	/*private Collider2D climbingLadder;
	private Vector3 bottomPosition;*/

	public Transform groundCheck;
	public LayerMask whatIsGround;
	public GameObject flooring;


	//private float spriteHeight;
	void Awake(){
		//spriteHeight = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
	}

	void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);

		if (moveCheck) {
		anim.SetFloat("Speed", Mathf.Abs(move));
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maximumSpeed,rigidbody2D.velocity.y);
		if (move > 0 && !marioFacingRight)
			Flipper();
			else if (move<0 && marioFacingRight)
				Flipper();
		}
		/// <summary>
		/// /**/
		/// </summary>
		/// <param name="other">Other.</param>
		/*if (climbingLadder != null) {
			float v = Input.GetAxis("Vertical");
			
			float dir = v == 0 ? 0 : Mathf.Sign(v);
			
			Collider2D ladder = FindLadderInDirection((int)dir, spriteHeight*0.2f);
			if (ladder != climbingLadder) {
				if (grounded) {
					climbingLadder = null;
					GetComponent<Rigidbody2D>().isKinematic = false;
				}
				else {
					GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				}
			}
			else {
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, dir * maximumSpeed * 0.5f);
			}
	}*/
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
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Barrel"){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//rigidbody2D.velocity = new Vector2 (0,0);
		if (grounded && other.gameObject.tag == "Ladder") {
		ladder = true;
		//moveCheck=false;
			//move=0;
			if (other.gameObject.tag == "Checker"){
				Physics2D.IgnoreCollision(flooring.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
				rigidbody2D.AddForce(new Vector2 (0, 16));
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Ladder") ladder = false;
	}
	
	void Update(){
		/*if (Input.GetAxis("Vertical") != 0 && climbingLadder == null) {
			
			int climbingDir = (int)Mathf.Sign(Input.GetAxis("Vertical"));
			float lookDistance;
			if (climbingDir > 0) lookDistance = spriteHeight*0.5f;
			else lookDistance = spriteHeight*0.2f;
			
			climbingLadder = FindLadderInDirection(climbingDir, lookDistance);
		}
		if (climbingLadder != null) {
			GetComponent<Rigidbody2D>().isKinematic = true;*/
		LadderClimb();
	}

	void LadderClimb(){
		if (anim.GetBool("Ladder") == false && grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			//rigidbody2D.isKinematic = true;					// disable gravity to allow static Y-axis movement
			//rigidbody2D.velocity = new Vector2(0, 0);
		}
		
		if (ladder && Input.GetAxis ("Vertical") > 0 && grounded){
			anim.SetBool("Ladder", ladder);
			transform.Translate (Vector2.up * (maximumSpeed-1.5f) * Time.deltaTime);
			rigidbody2D.gravityScale=0;
			}

		if (Input.GetAxis ("Vertical") < 0)
			transform.Translate (-Vector2.up * (maximumSpeed-1.5f) * Time.deltaTime);

		else if(!ladder) {
			anim.SetBool("Ladder",ladder);
			rigidbody2D.gravityScale=1;
		}
	}
	

	void Flipper (){

		marioFacingRight = !marioFacingRight;

		Vector3 TheScale = transform.localScale;

		TheScale.x *= -1;

		transform.localScale = TheScale;
	}	

	/*Collider2D FindLadderInDirection(int dir, float distance) {
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position+bottomPosition, new Vector2(0, dir), distance, 1 << LayerMask.NameToLayer("Ladder"));  
		return hit.collider;*/
	}

 
