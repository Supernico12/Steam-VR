using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryhponController : MonoBehaviour {



    bool isGrounded;

    void Move()
    {
        if (isGrounded)
        {
            Run();
        }else
        {
            Fly();
        }
    }

    void Run()
    {

    }
    void Fly()
    {
        //Fly
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
