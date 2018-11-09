using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MagazineSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] magazines;

    Interactable interactable;
    Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;



    void Start()
    {
        interactable = GetComponent<Interactable>();
    }


    void HandHoverUpdate(Hand hand)
    {

        GrabTypes startingGrabTypes = hand.GetGrabStarting();

        if (startingGrabTypes != GrabTypes.None)
        {

            WeaponStats otherStats = hand.otherHand.GetComponentInChildren<WeaponStats>();
            WeaponType othertype = WeaponType.Pistol;
            if (otherStats != null)
            {
                othertype = otherStats.type;
            }
            GameObject magazine = Instantiate(magazines[(int)othertype], hand.transform.position, Quaternion.identity);
            hand.AttachObject(magazine, startingGrabTypes, attachmentFlags);


        }

    }


}
