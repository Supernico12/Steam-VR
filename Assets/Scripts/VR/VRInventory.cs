using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class VRInventory : MonoBehaviour
{


    [SerializeField] SteamVR_Input_Sources thisHand;
    [SerializeField] SteamVR_Input_Sources otherHand;
    [SerializeField] GameObject hand1;
    [SerializeField] GameObject hand2;

    [SerializeField] GameObject[] placeHolders;


    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.__actions_default_in_Inventory.GetStateDown(thisHand))
        {
            SpawnPalceHolders(hand1);
        }

    }

    void SpawnPalceHolders(GameObject hand)
    {
        Transform[] position = new Transform[3];
        for (int i = 0; i < placeHolders.Length; i++)
        {
            position[i] = hand.transform.Find("SpawnPosition" + i);
        }

        for (int i = 0; i < placeHolders.Length; i++)
        {
            Instantiate(placeHolders[i], position[i].position, Quaternion.identity);
        }



    }



}
