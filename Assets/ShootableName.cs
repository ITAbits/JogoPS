using UnityEngine;
using System.Collections;

public class ShootableName : MonoBehaviour {

	public Color destroyedColor;
	public TextMesh text;

	public MeshRenderer renderer;
	public Collider collider;

	public void Start() {
		gameObject.AddComponent(typeof(BoxCollider));
	}

	public void Damage(Vector3 position)
	{
		//Check if health has fallen below zero
		renderer.material.SetColor("_Color", destroyedColor);
	}
}
