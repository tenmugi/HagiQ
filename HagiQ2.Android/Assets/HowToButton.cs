using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToButton : MonoBehaviour
{
    private bool firstPush = false;

    public GameObject HowTo;
    public GameObject How1;

    public void Start()
    {
        HowTo.SetActive(false);
        How1.SetActive(false);
    }

    public void PressHowTo()
    {
        if (!firstPush)
        {
            HowTo.SetActive(true);
            How1.SetActive(true);
            
            firstPush = true;
        }
    }
}
