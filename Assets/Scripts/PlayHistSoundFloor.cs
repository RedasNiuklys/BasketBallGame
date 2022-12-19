using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHistSoundFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball"){
            AudioManager.Instance.PlaySFX("HitAreaSound");
        }
    }
}
