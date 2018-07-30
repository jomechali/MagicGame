using UnityEngine;
using System.Collections;

public class Buff
{
	private Unit attachedUnit;
	private UnitAttributes modifiers;
	private UnitAttributes temporaryModifiers;

	private bool alreadyApplied = false;
	private bool repeatable = false;

	private float remainingTime;

	public void BeginTurn ()
	{
		if (!alreadyApplied || repeatable)
		{
			attachedUnit.AddBuff (modifiers);
			//add to the temporary modifiers what is temporary, as stat modif, but not mana and life
		}
	}

	public void OnRemove ()
	{
		attachedUnit.RemoveBuff (temporaryModifiers);
	}
}

