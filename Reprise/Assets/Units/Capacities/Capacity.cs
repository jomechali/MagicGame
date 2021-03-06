﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacity {

	protected Unit executer;

	protected GameManager gameManager;

	protected bool executed = false;

	protected const int minimumCapacityPlayingFrame = 20;

	protected int curNumberOfPlayingFrames = 0;

	public Capacity(Unit _executer, GameManager _gameManager) {
		this.executer = _executer;
		this.gameManager = _gameManager;
	}

	public abstract bool CanBeUsed ();

	public virtual bool Execute (){
		if (executed && curNumberOfPlayingFrames >= minimumCapacityPlayingFrame)
			return true;

		curNumberOfPlayingFrames++;
		return false;
	}
}
