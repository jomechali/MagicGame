using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Constants : MonoBehaviour {

	public static float cellSize;
	public Transform spellBar;
	public Transform spellButton;
	public const int spellsBySpellBar = 8;

	public const float gapPercent = 0.05f;
	private Transform[] spellCells;

	public List<Unit> allUnits;

	[HideInInspector] public Tilemap blockingTileMap;
	[HideInInspector] public Tilemap walkableTileMap;

	void Awake() {

		blockingTileMap = GameObject.Find ("BlockingTilemap").GetComponent<Tilemap> ();
		walkableTileMap = GameObject.Find ("SimpleTilemap").GetComponent<Tilemap> ();

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

	public void OnSpellButtonClick(Transform button){
		
		int buttonClicked = button.GetSiblingIndex ();
		Debug.Log ("button clicked nb " + buttonClicked );
	}

}
