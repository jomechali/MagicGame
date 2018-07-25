using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothingCapacity : Capacity {


	public DoNothingCapacity(Unit _executer, Constants _gameManager) : base(_executer, _gameManager) {}

	public override bool CanBeUsed () {
		return true;
	}

	public override bool Execute () {
		return base.Execute();
	}
}
