using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text text;
    public int value = 0;
    public int SelectedCountNumber = 1;


    public void AddScoreOne(){
        value = value + SelectedCountNumber;
        text.text = value.ToString();
    }

    public void SetScoreFromPreposition(int value){
        SelectedCountNumber = value;    
    }
}
