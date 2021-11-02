using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    private bool firstPush = false;

    public void PressNext()
    {
        if(!firstPush)
        {
            SceneManager.LoadScene("quiz");
        }
    }
}
