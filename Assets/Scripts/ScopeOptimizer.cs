using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ScopeOptimizer : MonoBehaviour
{

    [SerializeField]
    Camera cam;

    private void OnAttachedToHand()
    {
        cam.enabled = true;


    }

    private void OnDetachedFromHand()
    {
        cam.enabled = false;


    }
}
