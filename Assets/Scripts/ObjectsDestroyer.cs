using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		Destroy(col);
	}
}
