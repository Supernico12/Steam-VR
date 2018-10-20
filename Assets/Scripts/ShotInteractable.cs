using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotInteractable : MonoBehaviour {
	

	public virtual void Interact ( ){
		Debug.Log("Intecacted with: "  + gameObject.name);
	}
}
