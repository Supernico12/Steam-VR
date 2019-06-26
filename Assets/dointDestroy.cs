using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dointDestroy : MonoBehaviour {

    public static dointDestroy playerInstance;

    public KeyCode[] codes;
    private void Awake()
    { 
        if(playerInstance == null)
        {

        DontDestroyOnLoad(this.gameObject);
            playerInstance = this;
        }
        else if(playerInstance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Debug.Log("Started ");
    }

    private void Update()
    {
        for( int i = 0; i < codes.Length; i++)
        {
            if (Input.GetKeyDown(codes[i])) {

                SceneManager.LoadScene(i + 1);
            }


        }
            
            
    }
}
