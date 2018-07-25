using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	private List<TurnPlayingObject> allPlayingObjects = new List<TurnPlayingObject> ();
	private TurnPlayingObject currentPlayingObject;

	public void AddObject(TurnPlayingObject objectToAdd)
	{
		Debug.Log ("object to add" + (objectToAdd != null) + ((Unit)objectToAdd).positionInGrid);

		IEnumerator<TurnPlayingObject> enumerator = allPlayingObjects.GetEnumerator ();

		int position = 0;
		while (enumerator.MoveNext () && enumerator.Current.GetInitiative () > objectToAdd.GetInitiative ())
			position++;

		Debug.Log ("unit added at position " + position);
		allPlayingObjects.Insert (position, objectToAdd);
	
	}

	// when all units have either do nothing or can't do something
	public void LaunchTurn()
	{
		Debug.Log ("new turn");
		if (allPlayingObjects.Count > 0) 
		{
			foreach (var playingObject in allPlayingObjects) 
			{
				playingObject.SetBudget(playingObject.GetBudget () + playingObject.GetIncrement ());
			}

			currentPlayingObject = allPlayingObjects [0];
			currentPlayingObject.BeginTurn ();
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
			currentPlayingObject.BeginTurn ();			
		}
	}

	public void RemoveTurnPlayingObject(TurnPlayingObject toRemove) 
	{
		allPlayingObjects.Remove (toRemove);
	}

	void Update()
	{
		if (currentPlayingObject != null)
		{
			if (currentPlayingObject.HasTurnEnded ())
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
