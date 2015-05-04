using UnityEngine;
using System.Collections;

public class ModifyControl : MonoBehaviour {

	public AudioClip click;
	int month = 1;
	bool pause = false;

	void OnLevelWasLoaded(int level){
		if(level == 1){
		month = GameControl.control.months + 1;
		}
	}

	void Update(){
		transform.position = Camera.main.transform.position;
		if(GameControl.control.months == month){
			if(GameControl.control.food <= 0){
				GameControl.control.food = 0;
				GameControl.control.people -= 3 + Random.Range(-1, 5);
				if(GameControl.control.people <= 0) Application.LoadLevel("GameOver");
			}
			if(GameControl.control.food>0)
				GameControl.control.food -= GameControl.control.people;
			if(GameControl.control.food<=0)
				GameControl.control.food = 0;
			month += 1;
			if(month == 12) month = 1;
			//Application.LoadLevel("GameOver");
		}
	}
	void OnGUI(){
		if(Application.loadedLevel==1){

			if(!pause){
				if(GameControl.control.people>GameControl.control.mines && GameControl.control.budget >= 50){
					if(GUI.Button(new Rect(Screen.width-150,Screen.height-150,140,40),"Build Mine -$50K") ){
						audio.PlayOneShot(click);
						GameControl.control.mines += 1;
						GameControl.control.budget -= 50;
					}
				}
				if(GameControl.control.resources>=1f&&GameControl.control.budget>=75){
					if(GUI.Button(new Rect(Screen.width-150,Screen.height-100,140,40),"Build Module -$75K")){
						audio.PlayOneShot(click);
						GameControl.control.modules += 1;
						GameControl.control.people += 3;
						GameControl.control.resources -=1;
						GameControl.control.budget -= 75;
					}
				}
			
				if(GameControl.control.science>1f){
					if(GUI.Button(new Rect(Screen.width-150,Screen.height-200,140,40),"Sell Research +$20K")){
						audio.PlayOneShot(click);
						GameControl.control.science -= 1f;
						GameControl.control.budget += 20;
					}
				}
				if(GameControl.control.science>2f&&GameControl.control.resources>2f&&GameControl.control.budget >= 60){
					if(GUI.Button(new Rect(Screen.width-150,Screen.height-250,140,40),"Buy Farm -60K")){
						audio.PlayOneShot(click);
						GameControl.control.resources -= 1.5f;
						GameControl.control.farms += 1;
						GameControl.control.budget -= 60;
					}
				}
			
				if(GameControl.control.budget>=5){
					if(GUI.Button(new Rect(Screen.width-150,Screen.height-50,140,40),"Buy Food -$5K")){
						audio.PlayOneShot(click);
						GameControl.control.food += 10;
						GameControl.control.budget -=5;
					}
				}

				if(GUI.Button(new Rect(50, Screen.height-50,80,50), "PAUSE")){
					pause = true;
					Time.timeScale = 0f;
				}
			}else{
					GUI.Label(new Rect(200, 50, 500, 30),"Click and Drag = Change Camera Perspective");
					GUI.Label(new Rect(200, 70, 500, 30),"Up/Down Arrows = Zoom in/out of Space Station");
					GUI.Label(new Rect(200, 90, 500, 30),"Right/Left Arrows = Change Planet Focus");
					GUI.Label(new Rect(200, 110, 500, 30),"1-4 = Change Game Speed");
					GUI.Label(new Rect(200, 150, 500, 30),"Food decreases by number of people each month.");
					GUI.Label(new Rect(200, 170, 500, 30),"Mines cost $50k and produce Resources."); 
					GUI.Label(new Rect(200, 190, 500, 30),"Modules cost $75K + 1.00 Resources and produce Science.");
					GUI.Label(new Rect(200, 210, 500, 30),"3 People move in with each module.");
					GUI.Label(new Rect(200, 230, 500, 30),"Game Over if not enough food for number of people at end of month...");
					if(GUI.Button(new Rect(50, Screen.height-50,80,50), "PAUSE")){
						pause = false;
						Time.timeScale = 0.75f;
					}
				}
		}
	}
}
