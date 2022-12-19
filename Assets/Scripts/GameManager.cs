using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public GameObject WristMeniu;

    private WristMenu wristMenu;

    public GameObject RightTeleportationRay;
    public GameObject LeftTeleportationRay;
    // Start is called before the first frame update
    void Awake()
    {
        wristMenu = WristMeniu.GetComponent<WristMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wristMenu.activewristUI == true){
            TurnOffTeleportRay();
        }else{
            TurnOnTeleportRay();
        }
    }

    void TurnOffTeleportRay(){
        RightTeleportationRay.SetActive(false);
        LeftTeleportationRay.SetActive(false);
    }

    void TurnOnTeleportRay(){
        RightTeleportationRay.SetActive(true);
        LeftTeleportationRay.SetActive(true);
    }
}
