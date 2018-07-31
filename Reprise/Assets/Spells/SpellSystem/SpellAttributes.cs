using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum TargetType
{
	Unit,
	Position,
}

public enum ShootType
{
	Anchored,
	Missile,
	Teleportation
}

public enum SpellType
{
	DirectDammages,
	StatusModification,
	ImmaterialInvocation,
	MaterialInvocation
}

public class SpellAttributes : ScriptableObject {

	// these default values are illequals, but they are used as neutral for the sum
	public float manaCost = 0;
	public float power = 0;

	public float channelTime = 1;

	public float spellIncrement = 1;
	public float spellTurnCost = 1;

	// target
	public TargetType targettype = TargetType.Position;
	public float range = 0;
	public List<Vector3Int> relativeShape = new List<Vector3Int> () {new Vector3Int(0,0,0)};
	public ShootType shootType = ShootType.Anchored;

	public SpellType spellType = SpellType.DirectDammages;


	#if UNITY_EDITOR
	[MenuItem("Assets/Create/Attributes/SpellAttributes")]
	public static void CreatedSpellAttributesAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save spell attributes", "New Spell Attributes", "asset", "Save Spell Attributes");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<SpellAttributes>(), path);
	}
	#endif

	// combination rules
	public static SpellAttributes operator + (SpellAttributes A, SpellAttributes B)
	{
		SpellAttributes result = new SpellAttributes ();

		// manacost/power
		result.manaCost = A.manaCost + B.manaCost;
		result.power = A.power + B.power;

		// channeltime, multiplicative version
		result.channelTime = A.channelTime * B.channelTime;

		// spell time stats, multiplicative version
		result.spellIncrement = A.spellIncrement * B.spellIncrement;
		result.spellTurnCost = A.spellTurnCost * B.spellTurnCost;

		// target properties
		result.targettype = (TargetType)Mathf.Max((int)A.targettype,(int)B.targettype);
		result.range = Mathf.Max (A.range, B.range);
		result.relativeShape = (A.relativeShape.Count > B.relativeShape.Count) ? A.relativeShape : B.relativeShape;
		result.power /= result.relativeShape.Count; // to dilute power
		result.shootType = (ShootType)Mathf.Max((int)A.shootType,(int)B.shootType);

		// spell type
		result.spellType = (SpellType)Mathf.Max((int)A.spellType,(int)B.spellType);

		return result;
	}
}
