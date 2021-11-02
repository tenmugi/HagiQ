using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public bool firstPush = false;

    public void PressBack()
    {
        if(!firstPush)
        {
            SceneManager.LoadScene("title");
        }
    }
}
