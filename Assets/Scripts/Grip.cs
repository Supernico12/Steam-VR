using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof ( Interactable))]
public class Grip : MonoBehaviour
{
    private Interactable interactable;
    [SerializeField] GrabTypes grabtypes;
    [EnumFlags]
	[SerializeField] Hand.AttachmentFlags  attachmentFlags = Hand.defaultAttachmentFlags & ( ~Hand.AttachmentFlags.SnapOnAttach ) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    [EnumFlags]
    [SerializeField] Hand.AttachmentFlags  secondGripAttachmentFlags = Hand.defaultAttachmentFlags | (Hand.AttachmentFlags.SecondHand);
    WeaponRecoil recoil;
    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------

    void Awake(){
        interactable = GetComponent<Interactable>();
        recoil = GetComponent<WeaponRecoil>();
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
        GrabTypes startingGrabType = hand.GetGrabStarting(grabtypes);
        bool isGrabed = hand.IsGrabEnding(gameObject);
        bool otherHandIsGrabed = hand.otherHand.IsGrabEnding(gameObject);

        if(isGrabed){
            if(!otherHandIsGrabed){
                 hand.AttachObject(gameObject , grabtypes , attachmentFlags);
            }else {
                hand.AttachObject(gameObject,grabtypes, secondGripAttachmentFlags);
            }
           
            hand.HoverLock(interactable);
            if(recoil != null){
                recoil.AddGrip();
            }
        }
        

        if(!isGrabed){
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
            if(recoil != null){
                recoil.RemoveGrip();
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