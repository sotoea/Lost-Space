using UnityEngine;
using System.Collections;

public class satelliteRotate : MonoBehaviour {
	
	public float a = 0;
	public float b = 0;
	public float r = 10f;
	public float theta = 0f;
	public float deltaT = 0.05f;
	
	public float ownRotation=1f;



	// Use this for initialization
	void Start () {
		Time.timeScale = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 0f){}
		if(Time.timeScale == 0.75f){
			theta = theta + deltaT*Mathf.Deg2Rad;
			Vector3 temp = transform.localPosition;
			temp.x = a + r*Mathf.Cos(theta);
			temp.z = b + r*Mathf.Sin(theta);
			transform.localPosition = temp;
		}
		if(Time.timeScale == 2f){
			theta = theta + deltaT*Mathf.Deg2Rad*2f;
			Vector3 temp = transform.localPosition;
			temp.x = a + r*Mathf.Cos(theta);
			temp.z = b + r*Mathf.Sin(theta);
			transform.localPosition = temp;
		}
		if(Time.timeScale == 5f){
			theta = theta + deltaT*Mathf.Deg2Rad*5f;
			Vector3 temp = transform.localPosition;
			temp.x = a + r*Mathf.Cos(theta);
			temp.z = b + r*Mathf.Sin(theta);
			transform.localPosition = temp;
		}
		if(Time.timeScale == 10f){
			theta = theta + deltaT*Mathf.Deg2Rad*10f;
			Vector3 temp = transform.localPosition;
			temp.x = a + r*Mathf.Cos(theta);
			temp.z = b + r*Mathf.Sin(theta);
			transform.localPosition = temp;
		}
		
		transform.Rotate(Vector3.up*Time.deltaTime*ownRotation);

		if(theta>=Mathf.PI*2) theta = 0;
		
	}
}
