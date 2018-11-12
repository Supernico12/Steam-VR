using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
public class SceneInteractable : ShotInteractable
{

    [SerializeField] int index;

    public override void Interact()
    {
       
        SceneManager.LoadScene(index);


    }


}
