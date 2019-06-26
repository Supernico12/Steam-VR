using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour {

    public int index = 1;
	void Start () {
        SceneManager.LoadScene(index);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
