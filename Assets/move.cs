using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float acceleration = 2.0f;
	private float realSpeed;
	
	// Update is called once per frame
	void Update () {
		if(realSpeed < speed) {
			realSpeed += acceleration * Time.deltaTime;
		}
		transform.position += Vector3.forward * realSpeed * Time.deltaTime;
	}
}
