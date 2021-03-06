﻿/*
 * Copyright (C) 2014 Francisco Manuel Garcia Moreno
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using System.Collections;

/// <summary>
/// A utility class
/// </summary>
public class Settings : MonoBehaviour{
	//--------------------------------------
	// Constants
	//--------------------------------------
	public const string CELL_TAG 			= "Cell";
	public const string BOUND_CELL_TAG 		= "BoundCell";
	public const string CRYSTAL_CELL_TAG 	= "CrystalCell";
	public const string ENEMY_TAG 			= "Enemy";
	public const string BULLET_TAG 			= "Bullet";

	//--------------------------------------
	// Unity Methods
	//--------------------------------------
	#region Unity
	void Start () {
		DontDestroyOnLoad (this);
	}
	#endregion
}
