using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class Quit : ShotInteractable
{

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Interact()
    {
        base.Interact();
        Application.Quit();


    }

}
