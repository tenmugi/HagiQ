using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start3 : MonoBehaviour
{
    private bool firstPush = false;

    public void PressStart()
    {
        if (!firstPush)
        {
            SceneManager.LoadScene("Quiz3");
            firstPush = true;
        }
    }

}
