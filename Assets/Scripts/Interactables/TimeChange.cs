using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeChange : ShotInteractable {

    [SerializeField] Material skybox;

    public override void Interact(){
        base.Interact();
        if(RenderSettings.skybox != skybox){
            RenderSettings.skybox = skybox;
        }
    }

}
