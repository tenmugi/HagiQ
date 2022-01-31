using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Correct4 : MonoBehaviour
{
    public static string CorrectAnswerText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Level4Quiz.CorrectAnswerText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
