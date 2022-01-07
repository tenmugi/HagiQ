using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next1 : MonoBehaviour
{
    private bool firstPush = false;

    public void PressNext()
    {
        if (!firstPush)
        {
            Level1Quiz.nowIndex++;
            SceneManager.LoadScene("quiz1");
        }
    }
}
