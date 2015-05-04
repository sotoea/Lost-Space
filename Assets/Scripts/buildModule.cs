using UnityEngine;
using System.Collections;

public class buildModule : MonoBehaviour {

	public int module;
	public int farm;
	bool done = false;
	public float size;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameControl.control.modules == module && !done){
			animation.Play();
			transform.localScale = new Vector3(size,size,size);
			done = true;
		}
		if(GameControl.control.farms == farm && !done){
			animation.Play();
			transform.localScale = new Vector3(size,size,size);
			done = true;
		}
	}
}
