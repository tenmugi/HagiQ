using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next2 : MonoBehaviour
{
    public void OnClickNextButton()
    {
        Level2Quiz.nowIndex++;
        SceneManager.LoadScene("quiz2");

        if (Level2Quiz.nowIndex == 26)
        {
            SceneManager.LoadScene("Finish2");
        }
    }
}
