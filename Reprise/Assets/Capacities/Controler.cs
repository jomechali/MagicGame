using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controler : MonoBehaviour {

	protected Unit toControl;
	protected Constants gameManager;

	public Controler() {}

	void Start() {
		this.toControl = gameObject.GetComponent<Unit> ();

		this.gameManager = FindObjectOfType<Constants> ();
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
