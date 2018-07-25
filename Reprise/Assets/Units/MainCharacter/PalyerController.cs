using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : Controler {

	public override bool ChooseAction (out Capacity chosenCapacity) {

		if(Input.GetKey(KeyCode.UpArrow)) {
			Vector3Int targetedCell = toControl.positionInGrid + new Vector3Int(0, 1, 0);
			Capacity potentialCapacity = new MoveCapacity(this.toControl, this.gameManager, targetedCell);
			if (potentialCapacity.CanBeUsed ()) {
				chosenCapacity = potentialCapacity;
				return true;
			}
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			Vector3Int targetedCell = toControl.positionInGrid + new Vector3Int(0, -1, 0);
			Capacity potentialCapacity = new MoveCapacity(this.toControl, this.gameManager, targetedCell);
			if (potentialCapacity.CanBeUsed ()) {
				chosenCapacity = potentialCapacity;
				return true;
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			Vector3Int targetedCell = toControl.positionInGrid + new Vector3Int(-1, 0, 0);
			Capacity potentialCapacity = new MoveCapacity(this.toControl, this.gameManager, targetedCell);
			if (potentialCapacity.CanBeUsed ()) {
				chosenCapacity = potentialCapacity;
				return true;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			Vector3Int targetedCell = toControl.positionInGrid + new Vector3Int(1, 0, 0);
			Capacity potentialCapacity = new MoveCapacity(this.toControl, this.gameManager, targetedCell);
			if (potentialCapacity.CanBeUsed ()) {
				chosenCapacity = potentialCapacity;
				return true;
			}
		}

		if (Input.GetKey (KeyCode.Escape)) {
			chosenCapacity = new DoNothingCapacity (this.toControl, this.gameManager);

			return true;
		}

		chosenCapacity = new DoNothingCapacity (this.toControl, this.gameManager);

		return false;
	}
}
