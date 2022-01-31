using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next3 : MonoBehaviour
{
    public void OnClickNextButton()
    {
        Level3Quiz.nowIndex++;
        SceneManager.LoadScene("Quiz3");

        if (Level3Quiz.nowIndex == 26)
        {
            SceneManager.LoadScene("Finish3");
        }
    }
}
