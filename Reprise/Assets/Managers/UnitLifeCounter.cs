using UnityEngine;
using System.Collections;

public class UnitLifeCounter : TimedLifeModifier
{
	public Unit attachedUnit
	{ get; set; }

	#region implemented abstract members of TimedLifeModifier
	public override void OnTimeEnded ()
	{
		Debug.Log ("timed life unit has to be killed");
	}
	public override void BeginTurn ()
	{
		Debug.Log ("timedlife decreased for unit");
	}
	#endregion
}

