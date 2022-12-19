using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activewristUI = false;
    public TextMeshProUGUI[] texts;
    private TextMeshProUGUI VolumeText = null;
    private TextMeshProUGUI StrengthText = null;
    public Slider volume;
    public Slider strength;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        //texts = GetComponentsInChildren<TextMeshProUGUI>();
        //volume = GetComponentsInChildren<Slider>().Where(s => s.name == "VolumeSlider").First();
        //strength = GetComponentsInChildren<Slider>().Where(s => s.name == "StrengthSlider").First();

        ball = GameObject.FindWithTag("Ball");
        foreach (var text in texts)
        {
            if(text.name == "Volume") VolumeText = text;
            if (text.name == "Strength") StrengthText = text;
        }
        strength.value = 2;
        XRGrabInteractable Xr = ball.GetComponent<XRGrabInteractable>();
        Xr.throwVelocityScale = strength.value;
        SetTextToValue();
        DisplayWristUI();
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayWristUI();
        }
    }



    //
    // Do "SliderValue" text box takes slider.value and displays
    //
    public void DisplayWristUI()
    {
        if (activewristUI)
        {
            wristUI.SetActive(false);
            activewristUI = false;
            Time.timeScale = 1;
        }
        else if(!activewristUI)
        {
            wristUI.SetActive(true);
            activewristUI = true;
            Time.timeScale = 0;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited");
    }

    public void ReturnMainMeniu()
    {
        SceneManager.LoadScene("MainMenu");

        Debug.Log("Returned main meniu");
    }
    public void SetTextToValue()
    {
        VolumeText.text = System.Math.Round(volume.value,2).ToString();
        StrengthText.text = System.Math.Round(strength.value,2).ToString();
    }
    public void SetStrength()
    {
        XRGrabInteractable Xr = ball.GetComponent<XRGrabInteractable>();
        Xr.throwVelocityScale = strength.value;
    }
}
