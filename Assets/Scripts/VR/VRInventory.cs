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


    GameObject[] placeHold1;



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
        Transform[] position = new Transform[placeHolders.Length];
        for (int i = 0; i < placeHolders.Length; i++)
        {
            position[i] = hand.transform.Find("SpawnPosition" + i);
        }

        DestroyPlaceholds();

        for (int i = 0; i < placeHolders.Length; i++)
        {
            placeHold1[i] = Instantiate(placeHolders[i], position[i].position, Quaternion.identity);
        }



    }

    public void DestroyPlaceholds()
    {
        foreach (GameObject placehold in placeHold1)
        {
            Destroy(placehold);
        }
    }



}
