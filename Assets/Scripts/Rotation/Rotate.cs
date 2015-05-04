using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float a = 0f;
	public float b = 0f;
	public float r = 10f;
	public float theta = 0f;
	public float deltaT = 0.05f;
	private Vector3 pos;
	public float ownRotation=1f;

	public GameObject rotateAround;

	// Use this for initialization
	void Start () {
	
	}

	void setTheta(float t){
		theta = t;
	}

	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 0f){
		//	theta = theta + deltaT*Mathf.Deg2Rad*);
			//Vector3 temp = transform.localPosition;
			//temp.x = a + r*Mathf.Cos(theta);
			//temp.z = b + r*Mathf.Sin(theta);
			//transform.localPosition = temp;
		}
		if(Time.timeScale == 0.75f){
			theta = theta + deltaT*Mathf.Deg2Rad;
			pos = transform.position;
			pos.x = (rotateAround.transform.position.x + r*Mathf.Cos(theta));
			pos.z = (rotateAround.transform.position.z + r*Mathf.Sin(theta));
			transform.position = pos;
		}
		if(Time.timeScale == 2f){
			theta = theta + deltaT*Mathf.Deg2Rad*2f;
			pos = transform.position;
			pos.x = (rotateAround.transform.position.x + r*Mathf.Cos(theta));
			pos.z = (rotateAround.transform.position.z + r*Mathf.Sin(theta));
			transform.position = pos;
		}
		if(Time.timeScale == 5f){
			theta = theta + deltaT*Mathf.Deg2Rad*5f;
			pos = transform.position;
			pos.x = (rotateAround.transform.position.x + r*Mathf.Cos(theta));
			pos.z = (rotateAround.transform.position.z + r*Mathf.Sin(theta));
			transform.position = pos;
		}
		if(Time.timeScale == 10f){
			theta = theta + deltaT*Mathf.Deg2Rad*10f;
			pos = transform.position;
			pos.x = (rotateAround.transform.position.x + r*Mathf.Cos(theta));
			pos.z = (rotateAround.transform.position.z + r*Mathf.Sin(theta));
			transform.position = pos;
		}

		transform.Rotate(Vector3.up*Time.deltaTime*ownRotation);

		if(theta>=Mathf.PI*2) theta = 0;

	}
}
