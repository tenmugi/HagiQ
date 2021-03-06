using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class CSVScript : MonoBehaviour
{
    public TextAsset CSV;
    public Text value3, value4, value5;
    public static int nowIndex = 1;
    public static string CorrectAnswerText;


    //CSVから分解した問題クラスを代入する配列
    public Question[] questions = new Question[500];
    public static string QuestionText { get; private set; }



    // Start is called before the first frame update
    void Start()
    {

        //CSVを各行で区切る
        string[] csv = CSV.text.Split('\n');
        Debug.Log(csv.Length);

        //全ての行の数だけループする（１行目から開始）
        for (int i = 1; i < csv.Length; i++)
        {
            //各行の要素を,で区切る
            string[] values = csv[i].Split(',');

            //０番目：カテゴリ
            string category = values[0];

            //１番目：レベル
            int level = 0;
            if (values[1] == "初級")
            {
                level = 1;
            }
            else if (values[1] == "中級")
            {
                level = 2;
            }
            else if (values[1] == "上級")
            {
                level = 3;
            }

            //２番目：問題文
            string questionText = values[2];

            List<string> quiz = new List<string>();

            //3~5番目：選択肢　配列でまとめる
            //values[3]A values[4]B values[5]
            string[] answers = { values[3], values[4], values[5] };


            //６番目：正解の配列番号　Aが0、Bが1、Cが2
            int answerIndex = 0;
            if (values[6] == "A")
            {
                answerIndex = 0;
            }
            else if (values[6] == "B")
            {
                answerIndex = 1;
            }
            else
            {
                answerIndex = 2;
            }



            //７番目：解説s
            string comment = values[7];

            Question q = new Question(category, level, questionText, answers, answerIndex, comment);

            //作成したquestionクラスを配列に入れる
            questions[i] = q;

        }



        questions[nowIndex].ShowLog();


        GetComponentInChildren<Text>().text = questions[nowIndex].question;
        value3.text = questions[nowIndex].answers[0];
        value4.text = questions[nowIndex].answers[1];
        value5.text = questions[nowIndex].answers[2];
    }


    public void OnClickAnswerButton(int answerIndex)
    {
        CorrectAnswerText = questions[nowIndex].GetCorrectAnswerText();

        if (questions[nowIndex].answerIndex == answerIndex)
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
