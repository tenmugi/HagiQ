using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level1Quiz : MonoBehaviour
{
    public TextAsset CSV;
    public Text value1, value2, value3;
    public Text value5;
    public static int nowIndex = 1;
    public static string CorrectAnswerText;

    //CSVから分解した問題クラスを代入
    public CSV1[] questions = new CSV1[27];
    public static string CSV1Text { get; private set; }

    public Text scoreText;
    public static int score = 0;


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

            CSV1 q = new CSV1(questionText, choices, answer, comment);

            //作成したCSV1クラスを配列に入れる
                questions[i] = q;
        }

        questions[nowIndex].ShowLog();

        GetComponentInChildren<Text>().text = questions[nowIndex].question;
        value1.text = questions[nowIndex].choices[0];
        value2.text = questions[nowIndex].choices[1];
        value3.text = questions[nowIndex].choices[2];
        value5.text = questions[nowIndex].comment;

        scoreText.GetComponentInChildren<Text>().text = score + "問正解！";
    }

    public void OnClickAnswerButton(int answer)
    {
        CorrectAnswerText = questions[nowIndex].GetCorrectAnswerText();

        if (questions[nowIndex].answer == answer)
        {
            score += 1;
            Debug.Log(score);
            SceneManager.LoadScene("Correct1");
        }
        else
        {
            SceneManager.LoadScene("Incorrect1");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
