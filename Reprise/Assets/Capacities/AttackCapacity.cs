using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCapacity : Capacity {

	private Unit target;

	public AttackCapacity(Unit _executer, Constants _gameManager, Unit _target) : base(_executer, _gameManager) {
		target = _target;
	}

	public override bool CanBeUsed () {
		if (!isAvailable)
			return false;
		
		return true;
	}

	public override bool Execute (){
		if (!executed) {
			//target.attributes.curLife -= (executer.tmpDammages - target.tmpDef);

			executed = true;
		}

		return base.Execute();
	}
}
