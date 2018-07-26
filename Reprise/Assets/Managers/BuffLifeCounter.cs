using UnityEngine;
using System.Collections;

public class BuffLifeCounter : TimedLifeModifier
{
	public Buff attachedBuff
	{ get; set; }

	#region implemented abstract members of TimedLifeModifier

	public override void OnTimeEnded ()
	{
		attachedBuff.OnTimeEnded ();
	}

	public override void BeginTurn ()
	{
		attachedBuff.BeginTurn ();
	}

	#endregion


}

