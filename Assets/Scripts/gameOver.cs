using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2.75f,Screen.height/2f,400,50), "You have no people left alive. Game Over...");

		if(GUI.Button(new Rect(Screen.width/2.5f,Screen.height/1.5f,250,50), "Reset and Start Over")){
			GameControl.control.Save(true);
			Application.LoadLevel("Menu");
		}
	}
}
