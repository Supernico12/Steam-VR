using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WeaponRecoil : MonoBehaviour {

		Rigidbody rb;
		[SerializeField] Transform forcePosition;
		[SerializeField] float force;
	
		void Start(){
			rb = GetComponent<Rigidbody>();
		}

		public void AddRecoil(){
			rb.AddForceAtPosition((-transform.forward + transform.up / 3) * force , forcePosition.position ,ForceMode.Impulse);
		}
}
