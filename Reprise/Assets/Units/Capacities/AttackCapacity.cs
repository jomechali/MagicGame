using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCapacity : Capacity {

	private Unit target;

	public AttackCapacity(Unit _executer, GameManager _gameManager, Vector3Int targettedCell) : base(_executer, _gameManager) 
	{
		target = gameManager.UnitOnTile (targettedCell);
	}

	public override bool CanBeUsed ()
	{
		return executer.currentAttributes.isAttackCapacityAvailable & (target != null);
	}

	public override bool Execute ()
	{
		if (!executed) {
			// temp, dumm formula to compute dammages
			target.currentAttributes.currentLife -= executer.currentAttributes.attack - target.currentAttributes.armor;
			executed = true;
		}

		return base.Execute();
	}
}
