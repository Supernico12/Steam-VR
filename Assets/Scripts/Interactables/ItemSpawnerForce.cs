using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerForce : ShotInteractable {
	
	[SerializeField] GameObject spawnObject;
	[SerializeField] protected Transform position;
	

	[SerializeField] float minTime = 0.5f;
	[SerializeField] float maxTime = 2f;
	[SerializeField] float force;
	bool isActivated = false;
	public override void Interact(){
		base.Interact();
		isActivated = !isActivated;
		if(isActivated){
			StartCoroutine(RandomSpawnTimer());
			
		}else {
			StopCoroutine(RandomSpawnTimer());
		}


		
	}

	IEnumerator RandomSpawnTimer(){
		float timeToWait = Random.Range(minTime,maxTime);

		yield return new WaitForSeconds(timeToWait);
		GameObject spawnobj = Instantiate(spawnObject,position.position,Random.rotation);
		Rigidbody rb=spawnobj.GetComponent<Rigidbody>();
		if( rb != null){
			rb.AddForce(position.forward * force , ForceMode.Impulse);
		}
		Destroy(spawnobj,10f);
		if(isActivated){
			StartCoroutine(RandomSpawnTimer());
		}
	}
}
