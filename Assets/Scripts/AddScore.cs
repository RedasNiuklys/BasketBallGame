using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public GameObject gameManager;
    public ParticleSystem particles;
    ScoreSystem scoreSystem;
    void Start()
    {
        scoreSystem = gameManager.GetComponent<ScoreSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball"){
            scoreSystem.AddScoreOne();
            if(particles != null) particles.Play();
            AudioManager.Instance.PlaySFX("ScorePoint");
        }
    }

}
