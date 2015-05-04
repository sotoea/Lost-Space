using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public AudioClip click;

	public float gameTime;
	public int years = 0;
	public int months = 1;
	public float dyears = 90f;
	public float dmonths = 7.5f;

	public GameObject planet1;
	public GameObject planet2;
	public GameObject planet3;
	public GameObject planet4;
	public GameObject SS;	 
	public float food = 10f;
	public float budget = 150f;
	public int people;
	public float science;
	public float resources;
	public int modules = 1;
	public int mines;
	public int farms;

	// Use this for initialization
	void Awake () {
		if(control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
		}else if(control != this){
			Destroy(gameObject);
		}
	}

	void OnLevelWasLoaded(int level){
		if(level == 1){
	
       		planet1 = GameObject.Find("1");
       		planet2 = GameObject.Find("2");
       		planet3 = GameObject.Find("3");
       		planet4 = GameObject.Find("4");
       		SS = GameObject.Find("SS");	
			people = 5;

			Load();

		}
	}
	
	// Update is called once per frame
	void Update(){

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		if(Application.loadedLevel == 1){
			gameTime += 0.005f*Time.timeScale;

			resources += mines*Time.deltaTime/150;
			science += modules*Time.deltaTime/100;
			food += farms*Time.deltaTime/10;

			if(gameTime>= dyears){
				years += 1;
				dyears += 90f;
			}
			if(gameTime>= dmonths){
				dmonths += 7.5f;
				months += 1;
				if(months >12){ 
					months = 1;
					if(food > 0)
						food -= people;
					if(food <= 0)
						food = 0;
				}
			}
		}
	}

	void OnGUI () {

		if(Application.loadedLevel==1){
			if(GUI.Button(new Rect(Screen.width-150,10,100,30),"Save")){
				Save(false);
				audio.PlayOneShot(click);
			}
			GUI.Box (new Rect (5, 5, 145, 165), "");
			GUI.Box (new Rect (5, 5, 145, 165), "");
			GUI.Box (new Rect (5, 5, 145, 165), "");

			GUI.Label(new Rect(25, 10, 150, 30),"Years: " + (years) + " Months: " + months);
			GUI.Label(new Rect(25, 30, 150, 30),"Treasury: $" + budget + "K");
			GUI.Label(new Rect(25, 50, 155, 30),"Resources: " + (resources.ToString("F2")));
			GUI.Label(new Rect(25, 65, 150, 30),"Science: " + (science.ToString("F2")));
			GUI.Label(new Rect(25, 80, 150, 30),"Mines: " + (mines));
			GUI.Label(new Rect(25, 95, 150, 30),"Modules: " + (modules));
			GUI.Label(new Rect(25, 115, 150, 30),"People: " + (people));
			GUI.Label(new Rect(25, 130, 150, 30),"Farms: " + (farms));
			GUI.Label(new Rect(25, 145, 150, 30),"Food: " + (food.ToString("F0")));

		}
		if(Application.loadedLevel==0){
			GUI.Label(new Rect(Screen.width/2f-50+50*Mathf.Cos(2.5f*Time.timeSinceLevelLoad),Screen.height/5f+30*Mathf.Sin(Time.timeSinceLevelLoad),200,30), "Lost Space");
			if(GUI.Button(new Rect(Screen.width/2f-110,Screen.height/1.5f,200,30),"Load Game")){
				audio.PlayOneShot(click);
				Application.LoadLevel("Game");
			}
			
			if(GUI.Button(new Rect(Screen.width/2f-110,Screen.height-100,200,30),"Reset Saved Data")){
				Save(true);
				audio.PlayOneShot(click);
			}
		}
	}
	
	public void Save(bool reset){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");

		PlayerInfo data = new PlayerInfo();

		if(!reset){
			data.gameTime = gameTime;
			data.years = years;
			data.months = months;
			data.dmonths = dmonths;
			data.dyears = dyears;
			data.planet1 = ((Rotate)planet1.GetComponent(typeof(Rotate))).theta;
			data.planet2 = ((Rotate)planet2.GetComponent(typeof(Rotate))).theta;
			data.planet3 = ((Rotate)planet3.GetComponent(typeof(Rotate))).theta;
			data.planet4 = ((Rotate)planet4.GetComponent(typeof(Rotate))).theta;
			data.SS = ((Rotate)SS.GetComponent(typeof(Rotate))).theta;
			data.food = food;
			data.budget = budget;
			data.people = people;
			data.science = science;
			data.resources = resources;
			data.mines = mines;
			data.modules = modules;
		}else{
			data.gameTime = 0f;
			data.years = 0;
			data.months = 1;
			data.dmonths = 7.5f;
			data.dyears = 90f;
			data.planet1 = 0f;
			data.planet2 = 0f;
			data.planet3 = 0f;
			data.planet4 = 0f;
			data.SS = 0f;
			data.food = 10f;
			data.budget = 200f;
			data.people = 5;
			data.science = 0;
			data.resources = 1;
			data.mines = 0;
			data.modules = 1;
			data.farms = 0;
		}

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath+"/PlayerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath+"/PlayerInfo.dat", FileMode.Open);

			PlayerInfo data = (PlayerInfo)bf.Deserialize(file);

			gameTime = data.gameTime;
			years = data.years;
			months = data.months;
			dyears = data.dyears;
			dmonths = data.dmonths;

			((Rotate)planet1.GetComponent(typeof(Rotate))).theta = data.planet1;
			((Rotate)planet2.GetComponent(typeof(Rotate))).theta = data.planet2;
			((Rotate)planet3.GetComponent(typeof(Rotate))).theta = data.planet3;
			((Rotate)planet4.GetComponent(typeof(Rotate))).theta = data.planet4;
			((satelliteRotate)SS.GetComponent(typeof(satelliteRotate))).theta = data.SS;
			food = data.food;
			budget = data.budget;
			people = data.people;
			science = data.science;
			resources = data.resources;
			modules = data.modules;
			mines = data.mines;
			farms = data.farms;
			file.Close();

		}
	}
}

[Serializable]
class PlayerInfo{
	public float gameTime;
	public int years;
	public int months;
	public float dyears;
	public float dmonths;

	public float planet1;
	public float planet2;
	public float planet3;
	public float planet4;

	public float SS;
	public float budget;
	public float food;
	public int people;
	public float science;
	public float resources;
	public int modules;
	public int mines; 
	public int farms;
}