using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManagerer : MonoBehaviour
{
    private enum MOVE_TYPE
    {
        RUN,
        STOP,
    }
    //初期状態の定義
    MOVE_TYPE move = MOVE_TYPE.RUN;
    Rigidbody2D rbody2D;
    //移動速度
    float speed;

    public GameObject GameOverTxt;
    public GameObject TitleButton;
    public bool isEnd = false;

    public GameObject QuizBG;
    public GameObject GoalBG;

    public GameObject Score;
    public int score = 0;

    public GameObject QuizCount;
    public int countdown = 20;

    public GameObject Incorrect;
    public QuizManager quizManager;


    //パネルをfalse



    // Start is called before the first frame update
    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        QuizBG.SetActive(false);
        Incorrect.SetActive(false);
        GoalBG.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }


    //物理演算（rigidbody)をFixedUpdateで処理
    //ひとまず走らせる
    private void FixedUpdate()
    {
        //右に向かって進む
        Vector3 scale = transform.localScale;
        if(move == MOVE_TYPE.RUN)
        {
            scale.x = 3; //右向き
            speed = 3;
        }
        else if(move == MOVE_TYPE.STOP)
        {
            scale.x = 3;
            speed = 0;
        }

        transform.localScale = scale; //scaleを代入
        //rigidboduにspeedを代入。y方向は動かないためそのまま
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
    }

    void Jump()
    {
        rbody2D.AddForce(Vector2.up * 500);
    }

    //正解したらゲーム再開
    public void CorrectRunner()
    {
        QuizBG.SetActive(false);
        Incorrect.SetActive(false);

        countdown -= 1;
        QuizCount.GetComponent<Text>().text = "残り" + countdown + "問";

        move = MOVE_TYPE.RUN;
    }

    //不正解でゲームオーバー
    public void wrongRunner()
    {
        move = MOVE_TYPE.STOP;

        Incorrect.SetActive(true);
        QuizBG.SetActive(false);

        //GameRestartを呼び出して1秒待つ
        Invoke("GameRestart", 3);
    }

    //Invoke用のやつ
    public void GameRestart()
    {
        //タイトルにもどる
        SceneManager.LoadScene("TitleScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Orange")
        {
            score += 1;
            Score.GetComponent<Text>().text = score　+ "個収穫";
            Destroy(collision.gameObject);
        }

        //クイズ開く
        if (collision.gameObject.tag == "OpenQuiz")
        {
            move = MOVE_TYPE.STOP;
            Destroy(collision.gameObject);
            QuizBG.SetActive(true);
        }

        if (collision.gameObject.tag == "GameOver")
        {
            GameOverTxt.SetActive(true);
            isEnd = true;
            Debug.Log("game over");
            //GameRestartを呼び出して2秒待つ
            Invoke("GameRestart", 3);
        }

        if(collision.gameObject.tag == "Goal")
        {
            move = MOVE_TYPE.STOP;
            isEnd = true;
            GoalBG.SetActive(true);
            Debug.Log("clear");
            Invoke("GameRestart", 5);
        }
    }
}
