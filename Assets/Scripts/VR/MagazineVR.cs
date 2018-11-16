using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class MagazineVR : MonoBehaviour
{
    [SerializeField] float dropRange;

    private Rigidbody rb;

    private Collider col;
    [SerializeField] Transform defaultPosition;

    [SerializeField] WeaponTypes type;
    [SerializeField] Transform grx;
    [SerializeField] float maxAmmo = 1;
    private Interactable interactable;



    WeaponController weapon;
    float currentAmmo;
    public bool isAttached = true;
    bool getBack;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        col = GetComponent<Collider>();
        //defaultPosition = transform.position;
        // defaultRotation = transform.rotation;
        interactable = GetComponent<Interactable>();
        weapon = GetComponentInParent<WeaponController>();
        currentAmmo = maxAmmo;


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

    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {

        if (weapon != null && isAttached)
        {
            weapon.hasMagazine = false;
            currentAmmo = weapon.GetAmmo();


        }
        isAttached = false;
        weapon = hand.otherHand.GetComponentInChildren<WeaponController>();
        if (weapon != null)
        {
            grx = weapon.transform.Find("Grx");
            defaultPosition = grx.transform.Find("MagazinePosition");
        }
    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        rb.isKinematic = false;

        col.isTrigger = false;
        Debug.Log("Detached");
    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {
        if (weapon != null)
        {
            //Debug.Log(defaultPosition + " : " +  (transform.position  - weapon.gameObject.transform.position) ) ;
            if (weapon.types == type)
            {
                if (!weapon.hasMagazine)
                {
                    float distance = Vector3.Distance(transform.position, weapon.transform.position);

                    if (getBack)
                    {
                        if (distance < dropRange)
                        {

                            hand.DetachObject(gameObject);
                            //hand.HoverUnlock(interactable);
                            MagazineOnWeapon();
                            getBack = false;
                        }
                    }
                    else if (distance > dropRange)
                    {
                        getBack = true;

                    }
                }
            }
        }
    }

    void MagazineOnWeapon()
    {
        weapon.hasMagazine = true;
        rb.isKinematic = true;
        col.isTrigger = true;
        transform.SetPositionAndRotation(defaultPosition.position, defaultPosition.rotation);
        if (!transform.IsChildOf(grx))
        {

            transform.SetParent(grx);

            col.enabled = false;
        }
        weapon.Reload(currentAmmo);
        WeaponVR w = weapon.GetComponent<WeaponVR>();
        if (w != null)
            w.SetMagazine(transform);

        WeaponGrab l = weapon.gameObject.GetComponent<WeaponGrab>();
        if (l != null)
            l.SetMagazine(transform);
        isAttached = true;
        //col.enabled = false;
        // transform.SetParent(grx);

    }


    void Update()
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

    public void SetWeapon(WeaponController newweapon)
    {
        weapon = newweapon;
        grx = weapon.transform.Find("Grx");
        defaultPosition = grx.transform.Find("MagazinePosition");

    }
}

