using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float JumpForce=100f;
    public Transform spwanPoint;
    //public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        EventCenter.GetInstance().AddEventListener(EventDic.JumpLeft, JumpLeft);
        EventCenter.GetInstance().AddEventListener(EventDic.JumpMid, JumpMid);
        EventCenter.GetInstance().AddEventListener(EventDic.JumpRight, JumpRight);
    }



    private void OnDestroy()
    {

        EventCenter.GetInstance().RemoveEventListener(EventDic.JumpLeft, JumpLeft);
        EventCenter.GetInstance().RemoveEventListener(EventDic.JumpMid, JumpMid);
        EventCenter.GetInstance().RemoveEventListener(EventDic.JumpRight, JumpRight);
    }
    private void JumpRight()
    {
        rigidbody2d.AddForce(new Vector2(1, 1) * JumpForce, ForceMode2D.Impulse);
        //rigidbody2d.velocity = (new Vector2(1, 1) * JumpForce);
        LookAtPoint();
        //throw new NotImplementedException();
    }

    private void JumpMid()
    {
        //rigidbody2d.velocity = (new Vector2(0, 1) * JumpForce*3);
        rigidbody2d.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);

        LookAtPoint();
        //throw new NotImplementedException();
    }

    private void JumpLeft()
    {
        rigidbody2d.AddForce(new Vector2(-1, 1) * JumpForce, ForceMode2D.Impulse);
        //rigidbody2d.velocity = (new Vector2(-1, 1) * JumpForce);

        LookAtPoint();
        //throw new NotImplementedException();
    }

    bool testing = true;
    // Update is called once per frame
    void Update()
    {

        if (testing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                JumpMid();
            }
            if (Input.GetKey(KeyCode.A))
            {
                JumpLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                JumpRight();
            }
        }

        if (ControlAreaMgr.instance.lockControlArea == true)
        {
            rigidbody2d.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;

            LookAtPoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name== "PlayerAttackArea")
        {
            transform.position = spwanPoint.position;
            transform.up = Vector2.up;


        }
    }


    private void LookAtPoint()
    {
        transform.up = rigidbody2d.velocity;
    }
}
