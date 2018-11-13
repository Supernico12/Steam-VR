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


    //GameObject[] placeHold1;
	List<GameObject> placeHold1 = new List<GameObject>();



    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.__actions_default_in_Inventory.GetStateDown(thisHand))
        {
            SpawnPalceHolders(hand1);
        }

	 if (SteamVR_Input.__actions_default_in_Inventory.GetStateDown(otherHand))
        {
            SpawnPalceHolders(hand2);
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
           GameObject obj = Instantiate(placeHolders[i], position[i].position, Quaternion.identity);
            WeaponSpawner spawner = obj.GetComponent<WeaponSpawner>();
            spawner.SetInventory(this);
		placeHold1.Add(obj);
        }



    }

    public void DestroyPlaceholds()
    {
        foreach (GameObject placehold in placeHold1)
        {
	if(placehold != null)
            Destroy(placehold);
        }
	placeHold1.Clear();
    }



}
