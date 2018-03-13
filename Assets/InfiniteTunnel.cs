using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTunnel : MonoBehaviour {

	public float TeleportDistance;
	public int numTeleports = 1;
	public GameObject camera;

	// Update is called once per frame
	void Update () {
		if(camera.transform.position.z > numTeleports * TeleportDistance) {
			numTeleports++;
			transform.position += Vector3.forward * TeleportDistance;
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawCube(transform.position + Vector3.forward * TeleportDistance, new Vector3(10, 10, 0.2f));
	}
}
