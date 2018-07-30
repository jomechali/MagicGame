using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	private class TurnPlayingObjectWithTimedModifiers
	{
		public TurnPlayingObject mainObject;
		public List<TimedLifeModifier> timedModifers;
		// this will be usefull in case of change of initiative or increment by spell
		public bool shouldPlay = false; // false : did nothing, not enough points to do something, true : points have been modified, hasnt played yet AND has enough points

		public TurnPlayingObjectWithTimedModifiers(TurnPlayingObject _mainObject)
		{
			mainObject = _mainObject;
			timedModifers = new List<TimedLifeModifier> ();
			shouldPlay = true;
		}

		public void BeginTurn ()
		{
			foreach (var currentModifier in timedModifers)
			{
				currentModifier.BeginTurn ();
				currentModifier.DecrementRemainingTime ();
			}

			mainObject.BeginTurn ();
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
		TurnPlayingObjectWithTimedModifiers objectGroup = allPlayingObjects.Find(x => x.mainObject == objectToModify);

		if (objectGroup != null)
		{
			objectGroup.timedModifers.Add (modifier);
		} 
		else 
		{
			Debug.Log ("object not found");
		}
	}

	// when all units have either do nothing or are unable to do something
	public void LaunchTurn()
	{
		Debug.Log ("new turn");
		if (allPlayingObjects.Count > 0) 
		{
			foreach (var playingObject in allPlayingObjects) 
			{
				playingObject.mainObject.SetBudget(playingObject.mainObject.GetBudget () + playingObject.mainObject.GetIncrement ());
				playingObject.shouldPlay = true;
			}

			currentPlayingObject = allPlayingObjects [0];
			currentPlayingObject.BeginTurn ();
		} 
		else 
		{
			Debug.Log ("no unit");
		}
	}

	private void OnTurnEnded() 
	{
		int previouslyPlayingObjectIndex = allPlayingObjects.FindIndex (x => currentPlayingObject == x);
		int nbObjects = allPlayingObjects.Count;
		if (previouslyPlayingObjectIndex == nbObjects - 1 && ShouldLaunchTurn ()) 
		{
			//begin the next turn
			LaunchTurn ();
		}
		else
		{
			currentPlayingObject = allPlayingObjects [(previouslyPlayingObjectIndex + 1) % nbObjects ];
			if (currentPlayingObject.shouldPlay)
			{
				currentPlayingObject.BeginTurn ();
			}
			else
			{
				OnTurnEnded ();
			}
		}
	}

	private bool ShouldLaunchTurn ()
	{
		return !(allPlayingObjects.Exists (x => x.shouldPlay == true));
	}

	public void RemoveTurnPlayingObject(TurnPlayingObject toRemove) 
	{
		int indexToRemove = allPlayingObjects.FindIndex (x => currentPlayingObject == x);
		allPlayingObjects.RemoveAt(indexToRemove);
	}

	void Update()
	{
		if (currentPlayingObject != null)
		{
			TurnPlayingObject currentObject = currentPlayingObject.mainObject;
			if (currentObject.HasTurnEnded ())
			{
				Debug.Log ("manager launch the next unit turn");
				currentPlayingObject.shouldPlay = currentObject.GetBudget () >= currentObject.GetMinimalTurnCost (); // and find a way to take into account the donothing choice
				OnTurnEnded ();
			}
		}
		else
		{
			Debug.Log ("no current playing object ");
			if (allPlayingObjects.Count > 0)
			{
				Debug.Log ("manager is trying to launch a turn");
				LaunchTurn ();
			}
		}
	}
}
