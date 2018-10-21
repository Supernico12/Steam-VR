using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
public class PlayScene : ShotInteractable
{


    [SerializeField] float time;

    [SerializeField] Transform player;

    Hand[] hands;

    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene(1);


    }


}
