using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : ShotInteractable {


	[SerializeField] GameObject spawnObject;
	[SerializeField] protected Transform position;
	[SerializeField] float SpawnTimer = 1;
	float currentTime;

	public override void Interact(){
		base.Interact();
		if(currentTime < 0){
		currentTime = SpawnTimer;
		Instantiate(spawnObject,position.position,Quaternion.identity);
		}
		
	}

	void Update(){
		currentTime-= Time.deltaTime;
	}
}
