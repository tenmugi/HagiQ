using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    public GameObject QuizBG;


    //プレイヤースクリプトと繋げる
    public PlayerManagerer playerManager;

    private void Start()
    {
        generateQuestion();
    }


    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        //正解ルート
        playerManager.CorrectRunner();
    }

    public void incorrect()
    {
        Debug.Log("game over");
        //不正解ルート
        playerManager.wrongRunner();
    }


    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

    }

    void generateQuestion()
    {
        //問題をランダムで格納
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}
