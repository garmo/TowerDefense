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

public class UIProgressBar : MonoBehaviour {
	//--------------------------------------
	// Setting Attributes
	//--------------------------------------
	[SerializeField]
	private Texture		texBackground;	//texture for bacground bar
	[SerializeField]
	private Texture		texForeground;	//texture for life foreground bar

	//--------------------------------------
	// Private Attributes
	//--------------------------------------
	private float 		initialValue = 100;
	private float 		_value = 100;
	private Collider	collider;
	private GameObject	livingCharacter;

	//--------------------------------------
	// Getters & Setters
	//--------------------------------------
	public float Value {
		get {
			return this._value;
		}
		set {
			_value = value;
		}
	}

	//--------------------------------------
	// Unity Methods
	//--------------------------------------
	#region Unity
	void Awake(){
		_value = initialValue;
	}

	void OnGUI(){
		draw ();
	}
	#endregion

	//--------------------------------------
	// Public Methods
	//--------------------------------------
	public void init(float _initialValue, GameObject go){
		initialValue = _initialValue;
		_value = initialValue;
		livingCharacter = go;
	}

	//--------------------------------------
	// Private Methods
	//--------------------------------------
	private void draw(){
		if(livingCharacter == null) return;

		//Life bar
		Rect rcBg = new Rect(0,0, 60,14); //rect for the background
		Rect rcProgress = new Rect(0,0,((this._value)/this.initialValue)*56,10); //rect for the progress
		Rect label = new Rect(0,0,60,30);

		float offset = livingCharacter != null && livingCharacter.GetComponent<Collider>() != null ? livingCharacter.GetComponent<Collider>().bounds.size.y : 0;

		//screen point to locate in 3D space the progress bar on the top of the livingCharacter
		Vector3 point = Camera.main.WorldToScreenPoint(new Vector3(
			livingCharacter.transform.position.x,
			livingCharacter.transform.position.y + offset ,
			livingCharacter.transform.position.z 
			));
		
		rcBg.y = Screen.height-point.y;
		rcBg.x = point.x-30;
		rcProgress.x = rcBg.x+2;
		rcProgress.y = rcBg.y+2;
		label.x = rcBg.x+5;
		label.y = rcBg.y-12;
		
		//draw background and foreground textures and label with the progress value
		GUI.DrawTexture(rcBg, texBackground);
		GUI.DrawTexture(rcProgress, texForeground, ScaleMode.ScaleAndCrop);
		GUI.Label(label, this._value.ToString());
	}
}
