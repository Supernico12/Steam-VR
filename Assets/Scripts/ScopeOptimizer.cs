using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ScopeOptimizer : MonoBehaviour {

	[SerializeField]
	Camera cam;

	private void OnAttachedToHand()
    {
		cam.enabled = true;
		Debug.Log("enabeling Camera");

    }

	private void OnDetachedFromHand()
    {
		cam.enabled = false;
		Debug.Log("camera not enable");

    }
}
