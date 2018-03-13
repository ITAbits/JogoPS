using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class NameSpawner : MonoBehaviour {

	public TextMesh TextPrefab;
	public float radius = 1.0f;
	public float minDistance = 5.0f;
	public float maxDistance = 15.0f;
	// Use this for initialization
	void Start () {
		var text = Resources.Load<TextAsset>("bixos").ToString();
		var bixos = Regex.Split(text, "\r\n|\r|\n");
		var totalDistance = 0.0f;
		for(int i = 0; i < bixos.Length; i++)
		{
			var bixo = bixos[i];
			var floatingText = Instantiate<TextMesh>(TextPrefab);
			floatingText.text = bixo;
			var circ = Random.insideUnitCircle * radius;
			var dist = Mathf.Lerp(minDistance, maxDistance, Random.value);
			var posz = totalDistance + dist;
			totalDistance += dist;
			floatingText.transform.position = new Vector3(circ.x, circ.y, posz);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
