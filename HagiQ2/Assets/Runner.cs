using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public LayerMask StageLayer;

    private enum MOVE_TYPE
    {
        RUN,
    }
    MOVE_TYPE move = MOVE_TYPE.RUN;
    Rigidbody2D rbody2D;
    float speed;


    // Start is called before the first frame update
    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        float horizonkey = Input.GetAxis("Horizontal");

        if (horizonkey == 0)
        {
            move = MOVE_TYPE.RUN;
        }

        if (GroundChk())
        {
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }

        }
    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        if (move == MOVE_TYPE.RUN)
        {
            speed = 5;
        }
        transform.localScale = scale;
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
    }

    void Jump()
    {
        rbody2D.AddForce(Vector2.up * 300);
    }

    bool GroundChk()
    {
        Vector3 startposition = transform.position;
        Vector3 endposition = transform.position - transform.up * -0.5f;

        Debug.DrawLine(startposition, endposition, Color.red);

        return Physics2D.Linecast(startposition, endposition, StageLayer);
    }

}
