using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private bool firstPush = false;

    public void Presstitle()
    {
        if (!firstPush)
        {
            SceneManager.LoadScene("TitleScene");
            firstPush = true;
        }
    }
}
