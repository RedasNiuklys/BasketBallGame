using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingHoop : MonoBehaviour
{
    public Timer timer;
    public GameObject board;
    public float minY = -0.01f;
    public float maxY = 0.4f;
    public float minZ = -0.5f;
    public float maxZ = 0.5f;
    float nextY;
    float nextZ;
    Vector3 direction = new Vector3(0,0,0);
    // Timer to get how fast for hoop to move
    //public Timer timer;
    public float speed = 2;
    // Randomiser
    // Get random spot, move towards it by speed and time, When reached get other random spot.
    private void Start()
    {
        nextY = Random.Range(minY, maxY);
        nextZ = 0.5f;
        Debug.Log(board.transform.position.y);
    }
    void Update()
    {
        if(timer.startTimer)
        {

            /// 
            /// Patikrinti kuria postiion local a rne naudto
            Debug.Log(board.gameObject.transform.position.y);
            direction = new Vector3(0, 0, nextZ);

            if (nextZ - board.transform.position.z < 0.001)
            {
                if (nextZ > 0)
                    nextZ = -0.5f;
                else
                {
                    nextZ = 0.5f;
                }
                //if (nextY < 0 && board.transform.position.y > 0)
                //{
                //    direction = new Vector3(0, MathF.Abs(nextY)+ board.transform.position.y, nextZ - board.transform.position.z);
                //}
                //else if (nextZ < 0 && board.transform.position.z > 0)
                //{
                //    direction = new Vector3(0, nextY - board.transform.position.y, MathF.Abs(nextZ) + board.transform.position.z);

                //}

                //else if (nextY < 0 && nextZ < 0 && board.transform.position.y > 0 && board.transform.position.z > 0)
                //{
                //    direction = new Vector3(0, MathF.Abs(nextY) + board.transform.position.y, MathF.Abs(nextZ) + board.transform.position.z);

                //}
                //else
                //{
                //    direction = new Vector3(0, nextY - board.transform.position.y, nextZ - board.transform.position.z);

                //}
                direction = new Vector3(0,0,nextZ);
            }


            //Debug.Log(direction.y);
            board.transform.position += direction *20 *Time.deltaTime;
        }

    }
}
