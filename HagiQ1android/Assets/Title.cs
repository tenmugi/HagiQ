using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool firstPush = false;

    public void PressTitle()
    {
        if(!firstPush)
        {
            SceneManager.LoadScene("Title");
            firstPush = true;
        }
    }
}
