using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum TargetType
{
	Unit,
	Position
}

public enum ShootType
{
	Missile,
	Teleportation,
	Anchored
}

public enum SpellType
{
	MaterialInvocation,
	ImmaterialInvocation,
	StatusModification,
	DirectDammages
}

public class SpellAttributes : ScriptableObject {

	public float manaCost = 0;
	public float power = 0;

	public float channelTime = 0;

	public float spellInitiave = 0;
	public float spellIncrement = 0;
	public float spellTurnCost = 0;

	// target
	public TargetType targettype = TargetType.Position;
	public float range = 0;
	public List<Vector3Int> relativeShape = new List<Vector3Int> () {new Vector3Int(0,0,0)};
	public ShootType shootType = ShootType.Missile;

	public SpellType spellType = SpellType.DirectDammages;


	#if UNITY_EDITOR
	[MenuItem("Assets/Create/Attributes/SpellAttributes")]
	public static void CreatedSpellAttributesAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save spell attributes", "New Spell Attributes", "asset", "Save Spell Attributes");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<SpellAttributes>(), path);
	}
	#endif

}
