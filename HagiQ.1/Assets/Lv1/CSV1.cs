using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSV1
{
    public string question;
    public string[] choices;
    public int answer;
    public string comment;

    public CSV1(string question, string[]choices, int answer, string comment)
    {
        this.question = question;
        this.choices = choices;
        this.answer = answer;
        this.comment = comment;
    }

    public string GetCorrectAnswerText()
    {
        return choices[answer];
    }

    //確認用の関数
    public void ShowLog()
    {
        Debug.Log("question:" + question + "\nchoices1:" + choices[0] + "choices2:" + choices[1] + "choices3:" + choices[2] + "\nanswer:" + answer + "\ncomment:" + comment);
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
