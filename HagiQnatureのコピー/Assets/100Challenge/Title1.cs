using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title1 : MonoBehaviour
{
    private bool firstPush = false;

    public void PressTitle()
    {
        if (!firstPush)
        {
            SceneManager.LoadScene("Title");
            Challenge.nowIndex = 1;
            Challenge.score = 0;
            firstPush = true;
        }
    }
}
