using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button[] buttons;

    public Button free = null;
    public Button zones = null;
    public Button hoops = null;
    private Vector3 offset = new Vector3(0,-20,0);
    public Slider hover;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>(true);
        hover = GetComponentInChildren<Slider>();
        hover.gameObject.SetActive(false);

    }
    public void OnFreeClicked()
    {
        free = buttons.Where(b => b.name == "Free").First();
        hover.gameObject.SetActive(true);

        hover.transform.SetParent(free.transform,true);
        hover.transform.localPosition = offset;

    }
    public void OnZonesClicked()
    {
        zones = buttons.Where(b => b.name == "Zones").First();
        hover.gameObject.SetActive(true);

        hover.transform.SetParent(zones.transform);
        hover.transform.localPosition = offset;
    }
    public void OnHoopsClicked()
    {
        hoops = buttons.Where(b => b.name == "Hoops").First();
        hover.gameObject.SetActive(true);

        hover.transform.SetParent(hoops.transform);
        hover.transform.localPosition = offset;
    }
    public void OnStartPressed()
    {
        // Check slider parent. Load scene accordingly
        if (hover.transform.parent.gameObject == free.gameObject)
        {
            SceneManager.LoadScene("Level1");
        }
        else if(hover.transform.parent.gameObject == zones.gameObject)
            {
            SceneManager.LoadScene("Level2_Re");

        }
        else if(hover.transform.parent.gameObject == hoops.gameObject)
            {
            SceneManager.LoadScene("Level3_Re");

        }

    }
}
