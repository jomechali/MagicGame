using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttributes : MonoBehaviour {

	// turn it into unitbreed, not a monobehaviour but define externally
	public float maxLife;
	public float currentLife;

	public float maxMana;
	public float currentMana;

	public float attack;
	public float armor;

	public UnitAttributes (UnitAttributes other)
	{
		maxLife = other.maxLife;
		currentLife = other.currentLife;

		maxMana = other.maxMana;
		currentMana = other.currentMana;

		attack = other.attack;
		armor = other.armor;
	}
}
