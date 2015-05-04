using UnityEngine;
using System.Collections;

public class simpleRotate : MonoBehaviour {
	public float rotateRate = 1f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up*Time.deltaTime*rotateRate);
		transform.Rotate(Vector3.left*Time.deltaTime*0.1f);
	}
}
