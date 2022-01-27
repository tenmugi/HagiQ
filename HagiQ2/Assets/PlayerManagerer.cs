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

    public GameObject Score;
    public int score = 0;

    //パネルをfalse

   

    // Start is called before the first frame update
    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        QuizBG.SetActive(false);
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

            if(Input.GetMouseButtonDown(0))
            {
                move = MOVE_TYPE.RUN;
            }
        }

        transform.localScale = scale; //scaleを代入
        //rigidboduにspeedを代入。y方向は動かないためそのまま
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
    }

    void Jump()
    {
        rbody2D.AddForce(Vector2.up * 500);
    }


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
            Score.GetComponent<Text>().text = "×"　+ score;
            Destroy(collision.gameObject);
        }

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
            isEnd = true;
            Debug.Log("clear");
        }
    }
}
