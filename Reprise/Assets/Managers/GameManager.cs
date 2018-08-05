using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

	public static float cellSize;
	public Transform spellBar;
	public Transform spellButton;
	public const int spellsBySpellBar = 8;

	public const float gapPercent = 0.05f;
	private Transform[] spellCells;

	public List<Unit> allUnits;

	[HideInInspector] public Tilemap blockingTileMap;
	[HideInInspector] public Tilemap walkableTileMap;
	[HideInInspector] public TurnManager turnManager;

	void Awake() {

		blockingTileMap = GameObject.Find ("BlockingTilemap").GetComponent<Tilemap> ();
		walkableTileMap = GameObject.Find ("SimpleTilemap").GetComponent<Tilemap> ();
		turnManager = gameObject.GetComponent<TurnManager> ();

		cellSize = GameObject.Find ("Grid").GetComponent<Grid> ().cellSize.x;

	}

	// Use this for initialization
	void Start () {
		Canvas canvas = FindObjectOfType<Canvas> ();
		Transform bar = Instantiate (spellBar, canvas.GetComponent<Transform>());

		Transform spellButtons = bar.GetChild (0);
		spellCells = new Transform[spellsBySpellBar];

		float buttonWeight = (1f - (spellsBySpellBar + 1f) * gapPercent) / spellsBySpellBar;

		for (int i = 0; i < spellsBySpellBar; i++) {
			
			spellCells[i] = Instantiate (spellButton, spellButtons);
			spellCells[i].GetComponent<RectTransform>().anchorMin = new Vector2( i * buttonWeight + (i + 1) * gapPercent,gapPercent);

			spellCells[i].GetComponent<RectTransform>().anchorMax = new Vector2((i + 1) * buttonWeight + (i + 1) * gapPercent, 1f - gapPercent);
		}
	}

	public void OnTurnEnded()
	{
		// temp, inefficient way to check if a unit is dead by lacking of life
		List<Unit> toRemove = new List<Unit> ();

		foreach (var unit in allUnits)
		{
			if (unit.currentAttributes.currentLife <= 0)
			{
				unit.OnDeath ();
				toRemove.Add (unit);
			}
		}

		foreach (var unitToRemove in toRemove) 
		{
			RemoveUnitFromTheGame (unitToRemove);
		}
		//allUnits.RemoveAll (x => toRemove.Contains (x));
	}

	public void RemoveUnitFromTheGame (Unit unitToRemove)
	{
		allUnits.Remove (unitToRemove);
		turnManager.RemoveTurnPlayingObject (unitToRemove);
		Object.Destroy (unitToRemove.gameObject);
	}

	public void OnSpellButtonClick(Transform button){
		
		int buttonClicked = button.GetSiblingIndex ();
		Debug.Log ("button clicked nb " + buttonClicked );
	}

	public Unit UnitOnTile(Vector3Int tile)
	{
		foreach (var unit in allUnits)
		{
			if (unit.positionInGrid == tile)
				return unit;
		}

		return null;
	}
}
