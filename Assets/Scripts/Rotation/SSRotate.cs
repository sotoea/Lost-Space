using UnityEngine;
using System.Collections;

public class SSRotate : MonoBehaviour {
	public float rotateRate = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward*Time.deltaTime*rotateRate);

	}
}
