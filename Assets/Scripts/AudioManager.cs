using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public Sound[] musicSounds,sfxSounds;
    public AudioSource musicSource, sfxSource;  

    private void Awake() {
    if(Instance == null){
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }else{
        Destroy(this.gameObject);
    }    
    }
    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x=>x.name == name);

        if(s == null){
            Debug.Log("Not found music");
        }else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }


    public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x=>x.name == name);

        if(s == null){
            Debug.Log("Not found sound sfx");
        }else{
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
