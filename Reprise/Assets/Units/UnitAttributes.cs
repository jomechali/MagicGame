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
}
