using UnityEngine;
using System.Collections;

public class ShootableName : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
	public Color destroyedColor;
	public TextMesh text;

	public void Start() {
		gameObject.AddComponent(typeof(BoxCollider));
	}

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		text.color = destroyedColor;
	}
}
