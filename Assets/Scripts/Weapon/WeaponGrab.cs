using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;



[RequireComponent(typeof(Interactable))]
public class WeaponGrab : MonoBehaviour
{

    [SerializeField] Transform offset;
    [SerializeField] GrabTypes grabtypes;
    Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    Interactable interactable;


    Hand.AttachmentFlags weaponFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.TurnOnKinematic) | (Hand.AttachmentFlags.TurnOffGravity) | (Hand.AttachmentFlags.VelocityMovement);
    Rigidbody rb;

    WeaponController weapon;
    [SerializeField] Transform magazine;
    bool isAutomatic;

    void Awake()
    {
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<WeaponController>();

        Debug.Log(weaponFlags);
        Debug.Log(attachmentFlags);
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
        GrabTypes startingGrabType = hand.GetGrabStarting(grabtypes);
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (startingGrabType != GrabTypes.None)
        {

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);


            hand.AttachObject(gameObject, startingGrabType, weaponFlags, attachmentOffset: offset);

        }
        else if (isGrabEnding)
        {

            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);


        }
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
            if (col == null)
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


        if (weapon != null)
        {

            if (isAutomatic)
            {
                if (SteamVR_Input._default.inActions.GrabPinch.GetState(hand.handType))
                {
                    weapon.Shoot();
                }
            }
            else
            {
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(hand.handType))
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
