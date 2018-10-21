﻿


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class SlowTime : ShotInteractable {


	[SerializeField] Transform player;
    public float time;
	Hand[] hands;

	public override void Interact(){
		base.Interact();
		Time.timeScale = time;
		
		
	}

	
}
