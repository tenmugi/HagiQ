using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class questionIndex : MonoBehaviour
{
    private bool firstPush = false;

    public void PressValue3()
    {
        if (!firstPush)
        {
            SceneManager.LoadScene("quiz");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
