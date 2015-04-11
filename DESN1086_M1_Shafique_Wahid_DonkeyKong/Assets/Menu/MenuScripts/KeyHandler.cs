using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {
	private Vector2[] blipPosition = new [] {
		new Vector2 (-1.815f, -0.326f),
		new Vector2 (-1.815f, -0.78f),
		new Vector2 (-1.815f, -1.24f)
	};

	public int selectedItem = 0;


	void blipper(){
		transform.position=blipPosition[selectedItem];
	}

	void checker (int selectedItem){
		if (selectedItem<2){
		if (Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevel(selectedItem+1);
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Return)){
			Application.Quit();
				print ("quit");
			}
		}
	}

	void Start (){
		blipper();
	}
	
	void Update(){
		checker (selectedItem);
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (selectedItem==0){
			selectedItem=blipPosition.Length-1;
			blipper();
		} else {
			selectedItem--;
			blipper();
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (selectedItem==blipPosition.Length-1){
				selectedItem=0;
				blipper();
			} else {
				selectedItem++;
				blipper();
			}
		}
	}
}
