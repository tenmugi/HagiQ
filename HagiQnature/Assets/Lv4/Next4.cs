using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next4 : MonoBehaviour
{
    public void OnClickNextButton()
    {
        Level4Quiz.nowIndex++;
        SceneManager.LoadScene("Quiz4");

        if (Level4Quiz.nowIndex == 26)
        {
            SceneManager.LoadScene("Finish4");
        }
    }
}
