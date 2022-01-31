using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class How1Button : MonoBehaviour
{
    private bool firstPush = false;

    public GameObject HowTo;
    public GameObject How1;
    public GameObject How2;

    public void Start()
    {
        HowTo.SetActive(true);
        How1.SetActive(true);
        How2.SetActive(false);
    }

    public void PressHow1()
    {
        if (!firstPush)
        {
            How1.SetActive(false);
            How2.SetActive(true);

            firstPush = true;
        }
    }
}
