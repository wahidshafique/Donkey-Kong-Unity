using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {
	Animator anim;
	new Rigidbody2D myRigidbody2D;

	public bool endGame = false; 
	private bool hammer = false;
	private bool marioFacingRight=true;
	private bool grounded = false;
	private bool ladder = false;
	private bool moveCheck = true;
	private float groundRad = 0.05f;

	private bool bottomTouch = false;
	private bool topTouch = false; 
	private float topRad= 0.05f;
	private float bottomRad = 0.05f;

	private float move;
	private float maximumSpeed=2f;
	private float jumpForce = 150f;
	private bool canJump = true; 

	public AudioSource deathClip;
	public AudioSource jumpClip;
	public AudioSource bg; 

	public Transform groundCheck;
	public Transform topCheckObject;
	public Transform bottomTouchObject; 

	public LayerMask whatIsBottom; 
	public LayerMask whatIsGround;
	public LayerMask whatIsTop;

	public GameObject flooring;
	private GameObject scoreCheck; 

	void Start () {
		scoreCheck = GameObject.Find("ScoreCheck");
		anim = GetComponent<Animator>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		if (!endGame){
		topTouch = Physics2D.OverlapCircle (topCheckObject.position, topRad, whatIsTop);
		bottomTouch = Physics2D.OverlapCircle (bottomTouchObject.position, bottomRad, whatIsBottom);
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
	}
	
	void Flipper (){
		
		marioFacingRight = !marioFacingRight;
		
		Vector3 TheScale = transform.localScale;
		
		TheScale.x *= -1;
		
		transform.localScale = TheScale;
	}	
	
	void OnCollisionEnter2D(Collision2D coll) {
		if ((coll.gameObject.tag == "Barrel" || coll.gameObject.tag == "Fireballs") && !hammer) {
			this.gameObject.tag = "DeadPlayer";
			this.myRigidbody2D.isKinematic = true;
			anim.SetBool("Death", true);
			grounded = true;
			deathClip.Play();
			Time.timeScale = 0;
			StartCoroutine(endSec());
			PlayerData.Instance.Health--;

		}
	}

	void OnTriggerStay2D(Collider2D other) {
		//rigidbody2D.velocity = new Vector2 (0,0);
		if (grounded && other.gameObject.tag == "Ladder" ) {
			if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0) {
				canJump = false;
				ladder = true;
				anim.SetBool("Ladder",true);
			}
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Ladder") {
			ladder = false;
			canJump = true;
			anim.SetBool("Ladder",ladder);
		}
	}
	
	void Update(){
		if (!endGame){
		if (!grounded && ladder) moveCheck = false;
		else moveCheck = true; 
		jump();
		LadderClimb();
		}
	}

	void jump (){
		if (grounded && Input.GetKeyDown(KeyCode.Space) && canJump){
			jumpClip.Play();
			anim.SetBool("Ground",false);
			myRigidbody2D.AddForce(new Vector2(0,jumpForce));
		}
	}

	void LadderClimb() {

		if (ladder && !hammer){
			scoreCheck.SetActive(false);
			float climbVel = 1.5f * Input.GetAxisRaw("Vertical");
			myRigidbody2D.velocity = Vector2.zero;
			myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVel);
			myRigidbody2D.gravityScale=0; 
			if (topTouch) {
				//Physics2D.IgnoreCollision(currentFloor, gameObject.GetComponent<Collider2D>());//TODO
				myRigidbody2D.isKinematic = true;
				topTouch = false;
			} 
			if (bottomTouch) {
				myRigidbody2D.isKinematic = true;
				bottomTouch = false;
			}
		} 
		else {
			scoreCheck.SetActive(true);
			myRigidbody2D.gravityScale=1;
			myRigidbody2D.isKinematic = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Hammer"){
			hammer = true; 
			anim.SetBool("HammerTime", true);
			bg.pitch = 2; 
			StartCoroutine (timedHammer());
			this.gameObject.tag = "Hammer";
		}
		if (other.gameObject.tag == "End"){
			endGame = true; 
			myRigidbody2D.velocity = Vector2.zero;
			anim.SetFloat("Speed", 0);
		}
	}
	
	IEnumerator timedHammer () {
		yield return new WaitForSeconds(5);
		bg.pitch = 1; 
		anim.SetBool("HammerTime",false);
		hammer = false;
		this.gameObject.tag = "Player";
	}
	IEnumerator endSec () {
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1; 
		if (PlayerData.Instance.Health == 0) {
			Application.LoadLevel(0);
		} else {
			PlayerData.Instance.Timer = 5000f;
			Application.LoadLevel(4); 
		}
	}
}

 
