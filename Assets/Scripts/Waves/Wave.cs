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
using System.Collections.Generic;

[System.Serializable]
public class Wave {
	//--------------------------------------
	// Setting Attributes
	//--------------------------------------
	[SerializeField]
	private SubWave[] 		subwaves = new SubWave[1];	//subwaves with units to spawn in this wave

	//--------------------------------------
	// Private Attributes
	//--------------------------------------
	private bool 			finished = false;					//flag checks if it has finished or not this wave
	private int 			index;								//unique id to identify the wave in the collection of waves in the SpawnHandler 			
	private int				currentSubWaveIndex = 0;			//current active subwave index			

	//--------------------------------------
	// Delegates & Events
	//--------------------------------------
	public delegate void 	finishWave(int waveIndex);
	public static event 	finishWave onFinishWave;

	//--------------------------------------
	// Getters & Setters
	//--------------------------------------
	public int Index {
		get {
			return this.index;
		}
	}


	//--------------------------------------
	// Events
	//--------------------------------------
	void onFinishSubWave (){
		Debug.Log ("Finish Subwave");
	}

	//--------------------------------------
	// Public Methods
	//--------------------------------------
	public void init(int _index){
		index = _index;
	}

	public bool checkIfFishish(){
		bool finish = false;

		//dispatch event
		if(currentSubWaveIndex >= subwaves.Length && onFinishWave != null){
			finish = true;
			onFinishWave(index);
		}

		return finish;
	}

	public SubWave getNextSubWave(){
		SubWave subwave = null;

		if(!finished){
			subwave = subwaves[currentSubWaveIndex];
			currentSubWaveIndex++;

			if(currentSubWaveIndex >= subwaves.Length)
				finished = true; //update flag
		}

		return subwave;
	}
}
