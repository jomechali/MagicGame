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

	[HideInInspector] public UnitAttributes currentAttributes; // turn it into unitbreed
	private UnitAttributes baseAttributes;

	void Start()
	{
		
		gameManager = FindObjectOfType<Constants> ();
		gameManager.allUnits.Add (this);
		turnManager = FindObjectOfType<TurnManager> ();
		turnManager.AddObject (this);
		transform.position = gameManager.walkableTileMap.GetCellCenterWorld (positionInGrid);
		//baseAttributes = gameObject.GetComponent<UnitAttributes> ();
		//currentAttributes = new UnitAttributes (baseAttributes);

	}

	void Update() {
		if (isPlaying) {
			if (curUsedCapacity.Execute ()) {
				Debug.Log ("end turn");
				isPlaying = false;
				isTurn = false;
			}
		}
	}

	public bool HasTurnEnded ()
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

	public void AddBuff(UnitAttributes modifier)
	{
		
	}

	public void RemoveBuff(UnitAttributes modifier)
	{
		
	}
}
