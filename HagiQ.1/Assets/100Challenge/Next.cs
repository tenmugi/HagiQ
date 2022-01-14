using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void OnClickNextButton()
    {
        Challenge.nowIndex++;
        SceneManager.LoadScene("Quiz");

        if (Challenge.nowIndex == 101)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
