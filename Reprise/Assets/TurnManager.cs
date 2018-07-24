using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	private List<TurnPlayingObject> allPlayingObjects;
	private TurnPlayingObject currentPlayingObject;

	public void AddObject(TurnPlayingObject objectToAdd)
	{
		Debug.Log ("object to add" + (objectToAdd != null) + ((Unit)objectToAdd).positionInGrid);

		////temp : faire une initialisation propre quand tout sera en place
		if (allPlayingObjects == null) 
		{
			allPlayingObjects = new List<TurnPlayingObject> ();
			allPlayingObjects.Add (objectToAdd);
		} 
		else
		{
			IEnumerator<TurnPlayingObject> enumerator = allPlayingObjects.GetEnumerator ();

			int position = 0;
			Debug.Log (position);
			while (enumerator.MoveNext () && enumerator.Current.GetInitiative () > objectToAdd.GetInitiative ())
				position++;

			allPlayingObjects.Insert (position, objectToAdd);
		}
	}

	// when all units have either do nothing or can't do something
	public void LaunchTurn()
	{
		foreach (var playingObject in allPlayingObjects) 
		{
			playingObject.SetBudget(playingObject.GetBudget () + playingObject.GetIncrement ());
		}

		currentPlayingObject = allPlayingObjects [0];
		currentPlayingObject.BeginTurn ();
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
		if (currentPlayingObject != null && currentPlayingObject.IsTurnEnded ())
			OnTurnEnded ();
	}

	void Start()
	{
		allPlayingObjects = new List<TurnPlayingObject> ();
	}
}
