using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellOnPaper : ScriptableObject{

	public SpellAttributes resultingAttributes;

	public List<SpellAttributes> attributesModifiers;


	#if UNITY_EDITOR
	[MenuItem("Assets/Create/Attributes/Spell")]
	public static void CreatedSpellAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save spell", "New Spell", "asset", "Save Spell");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<SpellOnPaper>(), path);
	}
	#endif

	///////////////ecrire les regles de combinaison
	///////////////traduire le resultat en sort utilisable quand les unités seront mis en place, l ajout de bonus speciaux se fera ici, stockés dans cette classe
}
