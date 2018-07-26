using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TurnPlayingObject {

	float GetInitiative ();
	float GetBudget ();
	float GetMinimalTurnCost ();
	float GetIncrement ();
	void SetBudget(float newBudget);

	float BeginTurn (); // return the effective cost of the turn
	bool HasTurnEnded(); //return false if the corresponding unit is selecting an action or is executing an action, or if the spell has not already applied its modifiers(never)

	//bool CheckDeath ();

	//void OnDeath ();

}
