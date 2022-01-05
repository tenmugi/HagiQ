using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    private bool firstPush = false;

    public void PressNext()
    {
        if (!firstPush)
        {
            QuizManager.nowIndex++;
            SceneManager.LoadScene("Quiz");
        }
    }
}