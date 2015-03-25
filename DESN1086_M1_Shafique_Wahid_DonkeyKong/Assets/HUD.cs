using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public Text score = null;
	public Text highScore = null;
	public Text timer = null;
	//public Text health = null;

	public GameObject[] lives;
	// Unity Script Singleton:
	
	private static HUD instance = null;
	
	void Awake ()
	{
		lives = GameObject.FindGameObjectsWithTag("MarioLife");

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
	
	// Update score and high score text values each frame.
	void Update ()
	{
		//this.score.text = "" + PlayerData.Instance.Score ("000000");


		this.score.text =  PlayerData.Instance.Score.ToString("000000");
		this.highScore.text =  PlayerData.Instance.HighScore.ToString("000000");
		this.timer.text = PlayerData.Instance.Timer.ToString("0000");
		PlayerData.Instance.Timer -= Time.deltaTime * 100;
	//	health.text = PlayerData.Instance.Health.ToString();
		if (PlayerData.Instance.Health == 2)
		lives[1].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 1)
			lives[2].GetComponent<SpriteRenderer>().enabled = false;

		if (PlayerData.Instance.Health == 0)
			lives[3].GetComponent<SpriteRenderer>().enabled = false;
		//for (int i = 0; i < lives.Length; i++){
		//	lives[i].GetComponent<SpriteRenderer>().enabled = false;
		//}
		//if (PlayerData.Instance.Health == 3)
		//	lives
		
		//if (PlayerData.Instance.Health == 2)
		//	health.text = "Health: <color=yellow>2</color>";
		
		//if (PlayerData.Instance.Health == 1)
		//	health.text = "Health: <color=red>1</color>";
		
		//if (PlayerData.Instance.Health == 0)
		//	health.text = "Health: <color=magenta>0</color>";*/
		
		
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