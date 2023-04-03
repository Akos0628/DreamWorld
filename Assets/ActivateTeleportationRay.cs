using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportationRay;
    public GameObject rightTeleportationRay;

    public InputActionProperty leftActive;
    public InputActionProperty rightActive;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;

    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

		leftTeleportationRay.SetActive(!isLeftRayHovering && leftActive.action.ReadValue<float>() > 0.1f);

		bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

		rightTeleportationRay.SetActive(!isRightRayHovering && rightActive.action.ReadValue<float>() > 0.1f);

	}
}
