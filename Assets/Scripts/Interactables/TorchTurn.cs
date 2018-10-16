using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTurn : ShotInteractable {

	[SerializeField] ParticleSystem[] particles;
	bool isActive  = false;
	public override void Interact(){
		base.Interact();
		isActive = !isActive;
		foreach( ParticleSystem particle in particles){
			if(isActive){
				particle.Play();
			}else {
				particle.Stop();
			}
		}
		
	}
}
