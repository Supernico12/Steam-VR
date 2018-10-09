using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WeaponRecoil : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] Transform forcePosition;
    [SerializeField] float force;

    int grip = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddRecoil()
    {
        Vector3 recoilForce = (-transform.forward + transform.up / 3) * force;
        //recoilForce /= grip;
        rb.AddForceAtPosition(recoilForce, forcePosition.position, ForceMode.Impulse);
    }

    public void AddGrip()
    {
        grip++;
    }
    public void RemoveGrip()
    {
        grip--;
    }
}
