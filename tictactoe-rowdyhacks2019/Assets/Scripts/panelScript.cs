using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelScript : MonoBehaviour
{
    public GameObject Panel;
    int counter = 1;

    public void showhidePanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            Panel.gameObject.SetActive(false);
        }
        else
        {
            Panel.gameObject.SetActive(true);
        }
    }

    public void showPanel()
    {
        Panel.gameObject.SetActive(false);
        Time.timeScale = 1;
        counter = 1;
    }
}