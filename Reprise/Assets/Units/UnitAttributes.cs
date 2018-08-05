using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnitAttributes : ScriptableObject {

	// turn it into unitbreed, not a monobehaviour but define externally
	public float maxLife;
	public float currentLife;

	public float maxMana;
	public float currentMana;

	public float attack;
	public float armor;

	// capacities
	// Move
	public bool isMoveCapacityAvailable = true;
	public float moveBaseTimeCost = 1;

	// Attack
	public bool isAttackCapacityAvailable = true;
	public float attackBaseTimeCost = 1;

	// LaunchSpell
	public bool isLaunchSpellCapacityAvailable = true;
	public float launchSpellBaseTimeCost = 1;

	// in order to create it in the editor

	#if UNITY_EDITOR
	[MenuItem("Assets/Create/Attributes/UnitBreed")]
	public static void CreatedUnitBreedAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save unit breed", "New Unit Breed", "asset", "Save Unit Breed");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<UnitAttributes>(), path);
	}
	#endif

	// operations to manipulate the attributes

	// copy constructor
	public UnitAttributes (UnitAttributes other)
	{

		// turn it into unitbreed, not a monobehaviour but define externally
		maxLife = other.maxLife;
		currentLife = other.currentLife;

		maxMana = other.maxMana;
		currentMana = other.currentMana;

		attack = other.attack;
		armor = other.armor;

		// capacities
		// Move
		isMoveCapacityAvailable = other.isMoveCapacityAvailable;
		moveBaseTimeCost = other.moveBaseTimeCost;

		// Attack
		isAttackCapacityAvailable = other.isAttackCapacityAvailable;
		attackBaseTimeCost = other.attackBaseTimeCost;

		// LaunchSpell
		isLaunchSpellCapacityAvailable = other.isLaunchSpellCapacityAvailable;
		launchSpellBaseTimeCost = other.launchSpellBaseTimeCost;
	}
}
