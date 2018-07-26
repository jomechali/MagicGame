using UnityEngine;
using System.Collections;

public abstract class TimedLifeModifier
{
	public float remainingTime
	{ get; set; }

	public float decrement
	{ get; set; }

	abstract public void OnTimeEnded ();

	abstract public void BeginTurn ();
}

