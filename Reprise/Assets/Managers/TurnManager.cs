using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	private class TurnPlayingObjectWithTimedModifiers
	{
		public TurnPlayingObject mainObject;
		public List<TimedLifeModifier> timedModifers;

		public TurnPlayingObjectWithTimedModifiers(TurnPlayingObject _mainObject)
		{
			mainObject = _mainObject;
			timedModifers = new List<TimedLifeModifier> ();
		}
	}
	private List<TurnPlayingObjectWithTimedModifiers> allPlayingObjects = new List<TurnPlayingObjectWithTimedModifiers> ();

	private TurnPlayingObjectWithTimedModifiers currentPlayingObject;

	public void AddObject(TurnPlayingObject objectToAdd)
	{
		Debug.Log ("object to add" + (objectToAdd != null) + ((Unit)objectToAdd).positionInGrid);

		TurnPlayingObjectWithTimedModifiers adaptedObjectToAdd = new TurnPlayingObjectWithTimedModifiers (objectToAdd);
		IEnumerator<TurnPlayingObjectWithTimedModifiers> enumerator = allPlayingObjects.GetEnumerator ();

		int position = 0;
		while (enumerator.MoveNext () && enumerator.Current.mainObject.GetInitiative () > objectToAdd.GetInitiative ())
			position++;

		Debug.Log ("unit added at position " + position);
		allPlayingObjects.Insert (position, adaptedObjectToAdd);
	
	}

	public void AddTimedLifeModifer(TurnPlayingObject objectToModify, TimedLifeModifier modifier)
	{
		// s assurer que lobjet existe
		// ajouter le modifier
		// l appliquer une fois

	}

	// when all units have either do nothing or can't do something
	public void LaunchTurn()
	{
		Debug.Log ("new turn");
		if (allPlayingObjects.Count > 0) 
		{
			foreach (var playingObject in allPlayingObjects) 
			{
				playingObject.mainObject.SetBudget(playingObject.mainObject.GetBudget () + playingObject.mainObject.GetIncrement ());
			}

			currentPlayingObject = allPlayingObjects [0];
			currentPlayingObject.mainObject.BeginTurn ();
		} 
		else 
		{
			Debug.Log ("no unit");
		}
	}
	// changement d initiative

	private void OnTurnEnded() 
	{
		int previouslyPlayingObjectIndex = allPlayingObjects.FindIndex (x => currentPlayingObject == x);
		if (previouslyPlayingObjectIndex == allPlayingObjects.Count - 1) 
		{
			//miss the test before increment the time budget
			//begin the next turn
			LaunchTurn ();
		}
		else
		{
			currentPlayingObject = allPlayingObjects [previouslyPlayingObjectIndex + 1];
			currentPlayingObject.mainObject.BeginTurn ();			
		}
	}

	public void RemoveTurnPlayingObject(TurnPlayingObject toRemove) 
	{
		// find the right object to remove
		// allPlayingObjects.Remove (toRemove);
	}

	void Update()
	{
		// launch first modifiers
		if (currentPlayingObject != null)
		{
			if (currentPlayingObject.mainObject.HasTurnEnded ())
			{
				Debug.Log ("manager launch the next unit turn");
				OnTurnEnded ();
			}
		}
		else
		{
			Debug.Log ("no cuurent playing object" + allPlayingObjects.Count);
			if (allPlayingObjects.Count > 0)
			{
				Debug.Log ("manager is trying to launch a turn");
				LaunchTurn ();
			}
		}
	}

	void Start()
	{
	}
}
