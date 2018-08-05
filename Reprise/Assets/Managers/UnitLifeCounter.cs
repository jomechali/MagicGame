using UnityEngine;
using System.Collections;

public class UnitLifeCounter : TimedLifeModifier
{
	public Unit attachedUnit
	{ get; set; }

	#region implemented abstract members of TimedLifeModifier
	public override void OnRemove ()
	{
		Debug.Log ("timed life unit has to be killed");
		Unit.gameManager.RemoveUnitFromTheGame (attachedUnit);
	}
	public override void BeginTurn ()
	{
		Debug.Log ("timedlife has been decreased for unit");
	}
	#endregion
}

