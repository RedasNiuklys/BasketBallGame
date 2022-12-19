using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class Timer : MonoBehaviour
{
    [SerializeField]
    
    public float timeRemaining = 300;
    float initialValue;
    public TextMeshProUGUI timer1;
    public TextMeshProUGUI timer2;

    public GameObject startButton;
    public GameObject stopButton;

    
    public bool startTimer = false;
    private void Start()
    {
        initialValue = timeRemaining;
        //Time.timeScale = 1;
    }
    void Update()
    {
        if(startTimer)
        {
            //timer.enabled = true;
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Time.timeScale = 0;
            }
            int mins = Mathf.FloorToInt(timeRemaining / 60);
            int secs = Mathf.FloorToInt(timeRemaining % 60);
            timer1.text = string.Format("{0:00}:{1:00}", mins, secs);
            timer2.text = string.Format("{0:00}:{1:00}", mins, secs);
        }

    }
    public void StartTimer()
    {   
        startTimer = true;
        startButton.SetActive(false);
        stopButton.SetActive(true);
        //Debug.Log("Button worked");
    }

    public void StopTimer()
    {   
        startTimer = false;
        stopButton.SetActive(false);
        startButton.SetActive(true);
        timeRemaining = initialValue;
        //Debug.Log("Button worked");
    }
}
