using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleporation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCanel;
    //public XRRayInteractor leftRay;
    //public XRRayInteractor rightRay;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPost,out Vector3 leftNormal,out int leftPos,out bool leftValid);
        //bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPost, out Vector3 rightNormal, out int rightPos, out bool rightValid);

        leftTeleportation.SetActive(leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleporation.SetActive( rightCanel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
