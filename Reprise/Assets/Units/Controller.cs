using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour {

	protected Unit toControl;
	protected GameManager gameManager;

	public Controller() {}

	void Start() {
		this.toControl = gameObject.GetComponent<Unit> ();

		this.gameManager = FindObjectOfType<GameManager> ();
	}

	void Update() {
		if (toControl.IsWaitingForOrder ()) {
			Capacity cap;
			Debug.Log ("waiting for orders");
			if (ChooseAction (out cap)) {
				toControl.Play (cap);
				Debug.Log ("orders given");
			}
		}
	}

	public abstract bool ChooseAction (out Capacity chosenCapacity);
}
