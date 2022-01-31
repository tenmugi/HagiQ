using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Correct3 : MonoBehaviour
{
    public static string CorrectAnswerText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Level3Quiz.CorrectAnswerText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
