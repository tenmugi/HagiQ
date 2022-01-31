using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Correct : MonoBehaviour
{
    public static string CorrectAnswerText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Challenge.CorrectAnswerText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
