using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class WeaponSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject weapon;
    Interactable interactable;
    Hand.AttachmentFlags weaponFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.TurnOnKinematic) | (Hand.AttachmentFlags.TurnOffGravity) | (Hand.AttachmentFlags.VelocityMovement);
    VRInventory inventory;



    public void SetInventory(VRInventory inv)
    {
        inventory = inv;
    }

    void HandHoverUpdate(Hand hand)
    {

        GrabTypes startingGrabTypes = hand.GetGrabStarting();

        if (startingGrabTypes != GrabTypes.None)
        {

            GameObject instance = Instantiate(weapon, hand.transform.position, Quaternion.identity);
            Transform offset = instance.transform.Find("Grip").transform;
            Debug.Log(offset);

            hand.HoverLock(instance.GetComponent<Interactable>());
            hand.AttachObject(instance, startingGrabTypes, weaponFlags, attachmentOffset: offset);
            inventory.DestroyPlaceholds();








        }


    }





}
