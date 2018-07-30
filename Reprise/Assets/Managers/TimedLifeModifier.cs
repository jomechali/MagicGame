using UnityEngine;
using System.Collections;

public abstract class TimedLifeModifier
{
	public float remainingTime
	{ get; set; }

	public float decrement
	{ get; set; }

	public void DecrementRemainingTime ()
	{
		remainingTime -= decrement;
	}

	abstract public void OnRemove ();

	abstract public void BeginTurn ();
}

