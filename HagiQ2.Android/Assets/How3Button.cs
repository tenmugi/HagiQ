using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class How3Button : MonoBehaviour
{
    private bool firstPush = false;

    public GameObject HowTo;
    public GameObject How3;

    public void Start()
    {
        HowTo.SetActive(true);
        How3.SetActive(true);
    }

    public void PressHow3()
    {
        if (!firstPush)
        {
            How3.SetActive(false);
            HowTo.SetActive(false);

            firstPush = true;
        }
    }
}
