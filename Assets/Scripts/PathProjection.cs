using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PathProjection : MonoBehaviour
{

    LineRenderer lr;
    Rigidbody rb;
    Vector3 startPosition;
    Vector3 startVelocity;

    float IntialForce = 25;
    float InitialAngle = -40;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;
    public InputActionProperty aButton;
    public Slider strenghtSlider;

    public bool isGrabbed = false;

    Quaternion rot;

    public int i = 0;

    int NumberOfPoints = 20;
    bool wasPreced = false;

    float timer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        rot = Quaternion.Euler(InitialAngle, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Executer());


    }

    IEnumerator Executer()
    {
        if ((rightActivate.action.ReadValue<float>() > 0.1f) && isGrabbed == true)
        {
            wasPreced = true;
            DrawLine();

        }
        else
        {
            if (wasPreced == true)
            {
                GetComponent<XRGrabInteractable>().enabled = false;
                rb.AddForce(rot * (IntialForce * strenghtSlider.value / 2  * transform.forward), ForceMode.Impulse);
                lr.enabled = false;
                wasPreced = false;
                yield return new WaitForSeconds(3f);
                GetComponent<XRGrabInteractable>().enabled = true;
            }

        }
    }

    void DrawLine()
    {
        i = 0;
        lr.positionCount = NumberOfPoints;
        lr.enabled = true;
        startPosition = transform.position;
        startVelocity = rot * ( IntialForce * strenghtSlider.value / 2 * transform.forward)/rb.mass;
        lr.SetPosition(i, startPosition);
        for(float j = 0; i <= lr.positionCount-1; j += timer)
        {
            Vector3 linePosition = startPosition + j * startVelocity;
            linePosition.y = startPosition.y + startVelocity.y * j + 0.5f*Physics.gravity.y*j*j;
            lr.SetPosition(i, linePosition);
            i++;

        }

    }

    public void SetGrabbedTrue(){
        AudioManager.Instance.PlaySFX("CatchBall");
        this.isGrabbed = true;
    }

    public void SetGrabbedFalse(){
        this.isGrabbed = false;
    }
    
}
