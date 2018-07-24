using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, TurnPlayingObject {

	public const int NB_ELEMENTS = 5;
	public const int NB_CAPACITIES = 3;
	public const float smoothMoveFactor = 0.2F;
	public const int TIME_BUDGET_BY_TURN = 10;

	public static Constants gameManager;
	public static TurnManager turnManager;

	public Vector3Int positionInGrid; // to set when spawn

	private bool isPlaying = false;
	private bool isTurn = false;

	private Capacity curUsedCapacity;

	protected Controler controler;

	public float tmpDammages = 10F;
	public float tmpDef = 5F;

	void Start() {
		gameManager = FindObjectOfType<Constants> ();
		gameManager.allUnits.Add (this);
		turnManager = FindObjectOfType<TurnManager> ();
		turnManager.AddObject (this);
		Debug.Log (positionInGrid);
		transform.position = gameManager.walkableTileMap.GetCellCenterWorld (positionInGrid);

		//for tests since there is nothing but one unit
		turnManager.LaunchTurn();
	}

	void Update() {
		if (isPlaying) {
			if (curUsedCapacity.Execute ()) {
				isPlaying = false;
				isTurn = false;
			}
		}
	}

	public bool IsTurnEnded ()
	{
		return !isTurn;
	}

	public bool IsWaitingForOrder() 
	{
		return isTurn && !isPlaying;
	}

	public void Play(Capacity chosenCapacity)
	{
		isPlaying = true;
		curUsedCapacity = chosenCapacity;
		chosenCapacity.Execute ();
	}

	private float initiative = 100;
	private float budget = 0;
	private float increment = 1;

	public float GetInitiative ()
	{
		return initiative;
	}

	public float GetBudget ()
	{
		return budget;
	}

	public float GetMinimalTurnCost ()
	{
		return 1; //to find from capacities
	}

	public float GetIncrement ()
	{
		return increment;
	}

	public void SetBudget(float newBudget)
	{
		budget = newBudget;
	}

	public float BeginTurn ()
	{
		isTurn = true;
		return 1; //find cost of the playing capacity
	}
}
