using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TextAsset CSV;
    public Text value1, value2, value3;
    public static int nowIndex = 1;
    public static string CorrectAnswerText;

    //CSVから分解した問題クラスを代入
    public CSVScript[] questions = new CSVScript[100];
    public static string CSVScriptText { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        //csvを各行で区切る
        string[] csv = CSV.text.Split('\n');
        Debug.Log(csv.Length);

        //全ての行だけループする（1行目から開始）
        for (int i = 1; i < csv.Length; i++)
        {
            //各行の要素を,で区切る
            string[] values = csv[i].Split(',');

            //0番目：問題
            string questionText = values[0];

            //1〜３番目：選択肢（配列でまとめる）
            string[] choices = { values[1], values[2], values[3] };

            //4番目：正解の配列番号
            int answer = 0;
            if (values[4] == "1")
            {
                answer = 0;
            }
            else if (values[4] == "2")
            {
                answer = 1;
            }
            else
            {
                answer = 2;
            }

            //5番目：解説
            string comment = values[5];

            CSVScript q = new CSVScript(questionText, choices, answer, comment);

            //作成したCSVScriptクラスを配列に入れる
            questions[i] = q;
        }

        questions[nowIndex].ShowLog();

        GetComponentInChildren<Text>().text = questions[nowIndex].question;
        value1.text = questions[nowIndex].choices[0];
        value2.text = questions[nowIndex].choices[1];
        value3.text = questions[nowIndex].choices[2];
    }

    public void OnClickAnswerButton(int answer)
    {
        CorrectAnswerText = questions[nowIndex].GetCorrectAnswerText();

        if (questions[nowIndex].answer == answer)
        {
            SceneManager.LoadScene("correct");
        }
        else
        {
            SceneManager.LoadScene("incorrect");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
