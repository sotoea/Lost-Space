using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public int sceneToLoad;

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-50,Screen.height-100,105,30),"Current Screen: " + (Application.loadedLevel + 1));
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2, 100, 40), "Load Scene: " + (sceneToLoad+1))){
			Application.LoadLevel(sceneToLoad);
		}
	}
}
