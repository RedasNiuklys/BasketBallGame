using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayOnBackground : MonoBehaviour
{
    public string MusicName = "";

    
    void Start(){
        if(AudioManager.Instance != null) AudioManager.Instance.PlayMusic(MusicName);
    }
}
