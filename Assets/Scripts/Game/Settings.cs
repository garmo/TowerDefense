﻿using UnityEngine;
using System.Collections;

/// <summary>
/// A utility class
/// </summary>
public class Settings : MonoBehaviour{
	//--------------------------------------
	// Constants
	//--------------------------------------
	public const string CRYSTAL_CELL_TAG = "CrystallCell";
	public const string ENEMY_TAG = "Enemy";

	//--------------------------------------
	// Unity Methods
	//--------------------------------------
	#region Unity
	void Start () {
		DontDestroyOnLoad (this);
	}
	#endregion
}
