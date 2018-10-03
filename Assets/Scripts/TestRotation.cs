using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {


	[SerializeField] Transform transform1;
	[SerializeField] Transform transform2;




	public void SetTwoHandedObject(){
            float rotSpeed = 100* Time.deltaTime;
            //Vector3 rotation = Vector3.RotateTowards(transform1.position , transform2.position, 100, 0f);
			Vector3 lookRotation = transform1.position- transform2.position;
			 Debug.DrawRay(transform.position, lookRotation * 100, Color.red);
			 
			Quaternion rot = Quaternion.LookRotation(lookRotation);
            gameObject.transform.rotation = rot;
            // Vector3 direction;
        }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SetTwoHandedObject();
	}
}
