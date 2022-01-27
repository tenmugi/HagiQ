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
    public GameObject GameOverTxt;


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
        QuizBG.SetActive(false);
        GameOverTxt.SetActive(false);
    }

    public void incorrect()
    {
        Debug.Log("game over");
        GameOverTxt.SetActive(true);
        QuizBG.SetActive(false);
        //GameRestartを呼び出して2秒待つ
        Invoke("GameRestart", 3);
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
