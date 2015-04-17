using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public Text score = null;
	public Text highScore = null;
	public Text timer = null;
	public GameObject timerholder = null;
	private int myInt = (int) PlayerData.Instance.Timer;

	public GameObject[] lives;

	public bool livesActive = true; 
	
	private static HUD instance = null;
	private GameObject playercheck; 
	
	void Awake ()
	{
		if (instance == null)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	void Update ()
	{
		this.score.text =  PlayerData.Instance.Score.ToString("000000");
		this.highScore.text =  PlayerData.Instance.HighScore.ToString("000000");
		if (Application.loadedLevel == 5){
			playercheck = GameObject.Find("Mario");
			timerholder.SetActive(true);
			this.timer.text = PlayerData.Instance.Timer.ToString("0000");
			PlayerData.Instance.Timer -= Time.deltaTime * 100;

			lives = GameObject.FindGameObjectsWithTag("MarioLife");
			livesActive = false; 
		}

		if (PlayerData.Instance.Timer <= 0){
			if (PlayerData.Instance.Health <= 0){
				Application.LoadLevel(0);
				//PlayerData.Instance.Timer
			} else {
				PlayerData.Instance.Health--;
				Application.LoadLevel(4);}
		}


		if (PlayerData.Instance.Health == 2)
		lives[1].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 1)
			lives[0].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 0)
			lives[2].GetComponent<SpriteRenderer>().enabled = false;

		if (playercheck.GetComponent<MarioController>().endGame){
			//PlayerData.Instance.Score += myInt;
		}

	}
	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevel == 0)//returns to main menu
		{
			PlayerData.Instance.Score = 0;
			PlayerData.Instance.Health = 3; 
			Destroy (this.gameObject);
		}
	}
}