using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellOnPaper : ScriptableObject {

	public SpellAttributes resultingAttributes;

	[HideInInspector] public List<SpellAttributes> attributesModifiers; // this is designed to be used with runes


	#if UNITY_EDITOR
	[MenuItem("Assets/Create/Attributes/Spell")]
	public static void CreatedSpellAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save spell", "New Spell", "asset", "Save Spell");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<SpellOnPaper>(), path);
	}
	#endif

	public void ComputeResultingAttributes()
	{
		foreach (var attributeModifier in attributesModifiers) {
			resultingAttributes += attributeModifier;
		}
	}
	// use the base spell attributes to find the reel effect
	///////////////traduire le resultat en sort utilisable quand les unités seront mises en place, l ajout de bonus speciaux se fera ici, stockés dans cette classe
}
