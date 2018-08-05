using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCapacity : Capacity {

	private Vector3Int targetDestination;

	public MoveCapacity(Unit _executer, GameManager _gameManager, Vector3Int _targetDestination) : base(_executer, _gameManager) {
		targetDestination = _targetDestination;
	}

	public override bool CanBeUsed ()
	{
		if (!executer.currentAttributes.isMoveCapacityAvailable)
			return false; // capacity disabled
		
		foreach (var unit in gameManager.allUnits) {
			if (unit.positionInGrid == targetDestination)
			{
				return false;
			}	
		}

		WeightedTiles targetTile = (WeightedTiles)gameManager.blockingTileMap.GetTile (targetDestination);
		if (targetTile)
			return false; // blocking tile

		return true;
	}

	public override bool Execute ()
	{
		if(!executed) {
			Vector3 newPostionInWorldCoord = gameManager.walkableTileMap.GetCellCenterWorld (targetDestination);
			executer.GetComponent<Rigidbody2D> ().MovePosition (new Vector2 (newPostionInWorldCoord.x, newPostionInWorldCoord.y));
			executer.positionInGrid = targetDestination;

			executed = true; // one time only
		}

		return base.Execute();
	}
}
