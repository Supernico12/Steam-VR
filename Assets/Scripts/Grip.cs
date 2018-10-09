using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Grip : MonoBehaviour
{
    private Interactable interactable;
    [SerializeField] GrabTypes grabtypes;
    [EnumFlags]
    [SerializeField] Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);


    [SerializeField] Transform offset;

    [Header("Two Hands")]
    [SerializeField] bool isTwoHanded = false;
    [SerializeField] Transform parent;
    [SerializeField] Hand.AttachmentFlags secondGripAttachmentFlags = (Hand.AttachmentFlags.SecondHand);
    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------

    void Awake()
    {
        interactable = GetComponent<Interactable>();
        if (offset != null)
        {
            interactable.handFollowTransform = offset;
        }


    }
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

        GrabTypes startingGrabTypes = hand.GetGrabStarting();

        if (startingGrabTypes != GrabTypes.None)
        {
            if (!isTwoHanded)
            {
                hand.AttachObject(gameObject, startingGrabTypes, attachmentFlags, offset);
            }
            else
            {
                hand.SetSecondHand(parent);
                hand.AttachObject(gameObject, startingGrabTypes, Hand.AttachmentFlags.DetachFromOtherHand);
            }


        }


    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {


    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {


    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {

        bool IsGrabEnding = hand.IsGrabEnding(this.gameObject);
          Debug.Log(IsGrabEnding);
         

        if (IsGrabEnding)
        {
          hand.DetachObject(gameObject);

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
}