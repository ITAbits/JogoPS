using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnel : MonoBehaviour {

	// Use this for initialization
	public float seed = 0.0f;
	public float speed = 1.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360.0f * Mathf.PerlinNoise(seed, speed * Time.time));
	}
}
