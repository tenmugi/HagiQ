using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class How2Button : MonoBehaviour
{
    private bool firstPush = false;

    public GameObject HowTo;
    public GameObject How2;
    public GameObject How3;

    public void Start()
    {
        HowTo.SetActive(true);
        How2.SetActive(true);
        How3.SetActive(false);
    }

    public void PressHow2()
    {
        if (!firstPush)
        {
            How2.SetActive(false);
            How3.SetActive(true);

            firstPush = true;
        }
    }
}
