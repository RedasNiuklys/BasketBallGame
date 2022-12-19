using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHoop : MonoBehaviour
{
    public GameObject Hoop;
    public Transform StartPosition;
    public Transform EndPosition;
    public float smoothTime = 0.03F;
    private Vector3 velocity = Vector3.zero;
    public float verticalSpeed = 5f;
    public float speed = 0.001f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Hoop.transform.localPosition = StartPosition.localPosition;
        StartCoroutine(move());
    }

     IEnumerator move()
         {
             while (Hoop.transform.localPosition != EndPosition.localPosition)
             {
                 Vector3.Lerp(Hoop.transform.localPosition, EndPosition.localPosition, speed);
                 yield return new WaitForEndOfFrame();
             }
         }
}
