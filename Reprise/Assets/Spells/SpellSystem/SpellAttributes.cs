using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class SpellAttributes {

	float manaCost;
	float power;

	float channelTime;

	float spellInitiave;
	float spellIncrement;
	float spellTurnCost;

	// target
	TargetType targettype;
	float range;
	List<Vector3Int> relativeShape;
	ShootType shootType;

	SpellType spellType;

}
