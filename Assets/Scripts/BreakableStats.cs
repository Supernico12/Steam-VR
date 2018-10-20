using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStats : CharacterStats {


	[SerializeField]GameObject destroyedSelf;

	public override void Die(){

		GameObject spawn = Instantiate(destroyedSelf,transform.position,transform.rotation);
		Rigidbody rb = spawn.GetComponentInChildren<Rigidbody>();
		Rigidbody rigi = gameObject.GetComponent<Rigidbody>();
		rb.velocity = rigi.velocity;
		rb.angularVelocity = rigi.angularVelocity;
		Destroy(spawn,30f);
		base.Die();
	}
}
