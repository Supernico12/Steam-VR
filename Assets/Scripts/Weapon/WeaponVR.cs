using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class WeaponVR : MonoBehaviour
{

    //-------------------------------------------------------------------------




    private float attachTime;
    WeaponController weapon;
    public SteamVR_Input_Sources thishHand;
    [SerializeField] Transform magazine;
    


    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & ( ~Hand.AttachmentFlags.SnapOnAttach ) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    bool isAutomatic;
    private Interactable interactable;


    //-------------------------------------------------
    void Awake()
    {

        interactable = this.GetComponent<Interactable>();
        weapon = GetComponent<WeaponController>();


    }




    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {

    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {

    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {

    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {
        if (weapon.hasMagazine)
        {
            if (magazine != null)
            {
                Collider col = magazine.GetComponent<Collider>();
                col.enabled = true;
            }
        }

        isAutomatic = weapon.isAutomatic;
        MagazineVR othermagazine = hand.otherHand.GetComponentInChildren<MagazineVR>();
        if (othermagazine != null)
        {
			WeaponController col = hand.otherHand.GetComponentInChildren<WeaponController>();
			if(col == null)
			othermagazine.SetWeapon(weapon);
			
        }
    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        if (weapon.hasMagazine)
        {
            if (magazine != null)
            {
                Collider col = magazine.GetComponent<Collider>();
                col.enabled = false;
            }
        }

    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {

        if (hand.name == "LeftHand")
        {
            thishHand = (SteamVR_Input_Sources)1;
        }
        else { thishHand = (SteamVR_Input_Sources)2; }
        if (weapon != null)
        {

            if (isAutomatic)
            {
                if (SteamVR_Input._default.inActions.Teleport.GetState(thishHand))
                {
                    weapon.Shoot();
                }
            }
            else
            {
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(thishHand))
                {
                    weapon.Shoot();
                }
            }
        }
    }


    //-------------------------------------------------
    // Called when this attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusAcquired(Hand hand)
    {
    }


    //-------------------------------------------------
    // Called when another attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusLost(Hand hand)
    {
    }

    public void SetMagazine(Transform newMagazine)
    {
        magazine = newMagazine;
        Collider col = newMagazine.GetComponent<Collider>();
        col.enabled = true;
    }
}


