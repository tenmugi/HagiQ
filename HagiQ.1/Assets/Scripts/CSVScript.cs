using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVScript : MonoBehaviour
{
    public string question;
    public string[] choices;
    public int answer;
    public string comment;

    public CSVScript(string question, string[]choices, int answer, string comment)
    {
        this.question = question;
        this.choices = choices;
        this.answer = answer;
        this.comment = comment;
    }

    //確認用の関数
    public void ShowLog()
    {
        Debug.Log("question:" + question + "\nchoices:" + choices + "\nanswer:" + answer + "\ncomment:" + comment);
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
