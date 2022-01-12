using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next1 : MonoBehaviour
{
    public void OnClickNextButton()
    {
        Level1Quiz.nowIndex++;
        SceneManager.LoadScene("quiz1");

        if(Level1Quiz.nowIndex == 25)
        {
            SceneManager.LoadScene("Finish1");
        }
    }
}
