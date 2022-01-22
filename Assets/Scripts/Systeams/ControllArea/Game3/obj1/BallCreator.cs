using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEngine.EventSystems;

public class BallCreator : MonoBehaviour
{
    public GameObject swordObj;
    public GameObject heroObj;
    public GameObject fireSwordObj;
    public GameObject fireObj;
    public GameObject waterSwordObj;
    public GameObject waterObj;
    public int  ballSizeMax=4;
    public Transform ballSpwanPoint;
    public Transform topBorder;
    public GameObject balls;

    public int maxBall=0;
    public GameObject nowBall;
    public static BallCreator instance;
    System.Random random;

    static float arg0;
    private void Awake()
    {
        instance = this;
        arg0 = GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_name == "英雄").probability * 100f; //25 Test
    }
    int t;


    enum BallState
    {
        wait,
        moving,
    }
    BallState nowBallState;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatBall(ballSpwanPoint.position, (BallType)GetT(), 1);
            
        }

        SetT();
    }
    int counter=0;
    Queue<int> tQueue = new Queue<int>();
    int GetT()
    {
        var tempInt=tQueue.Dequeue();
        //Debug.Log("下一个球" + (BallType)tQueue.Peek());
        EventCenter.GetInstance().EventTrigger<string>(EventDic.SetNextBallImage, ((BallType)tQueue.Peek()).ToString());
        return tempInt;
    }

    private void SetT()
    {
        //Debug.Log(GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_name == "英雄").probability * 100f);
        if (counter == 0)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(0);
                tQueue.Enqueue(2);
            }
            //tQueue.Enqueue(0); tQueue.Enqueue(2);
        }
        if (counter == 1)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(4);
            }
        }
        if (counter == 2)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(2);
            }
        }
        if (counter == 3)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(1);
            }
        }
        if (counter == 4)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(1);
            }
        }
        if (counter == 5)
        {
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(4);
                //Debug.Log("下一个球" + (BallType)tQueue.Peek());
            }
        }
        if (counter > 5)
        {

            random = new System.Random();

            int temp = random.Next(0, 100);
            if (tQueue.Count <= 2)
            {
                tQueue.Enqueue(GetProbability(temp));
                //Debug.Log("下一个球"+(BallType)tQueue.Peek());
            }
        }

        //throw new NotImplementedException();
    }

    //static float arg0 = GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_name == "英雄").probability * 100f; //25 Test

    //static float arg5 = arg0 + arg1 + arg2 + arg3 + arg4 + GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_name == "水剑").probability * 100f; //100
    int GetProbability(int temp)
    {

        if (temp < arg0) return 0;
        return random.Next(1, 6);

    }
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventDic.CreatBall,CreatBall);
        EventCenter.GetInstance().AddEventListener<float>("ballMoveX", BallMoveX);
    }

    private void BallMoveX(float arg0)
    {
        if (nowBall != null)
        {
            nowBall.transform.position = new Vector3(arg0, nowBall.transform.position.y, 0);
        }

    }

    private void CreatBall()
    {

        if (ControlAreaMgr.instance.lockControlArea == false)
        {
                
            MovePointSetActiveAndCreatNewBall();
        }
        //throw new NotImplementedException();
    }

    public void CreatFristBall()
    {
        CreatBall(ballSpwanPoint.position, (BallType)GetT(), 1);
        nowBallState = BallState.wait;
    }

    private void MovePointSetActiveAndCreatNewBall()
    {

        if (ControlAreaMgr.instance.lockControlArea == false)
        {
            ControlAreaMgr.instance.LockControlArea();
            float x = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).x;
            if (x > 2) x = 2;
            if (x < -2) x = -2;
            //if(x>)
            //float x = Input.mousePosition.x;
            float y = topBorder.position.y - 0.1f;
            Vector3 tempPoint = new Vector3(x, y, 0);
            var tweener = nowBall.transform.DOMove(tempPoint, 0.1f);
            tweener.onComplete += () =>
            {
                CreatBall(ballSpwanPoint.position, (BallType)GetT(), 1);
                ControlAreaMgr.instance.UnLockControlArea();
            };
            nowBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
        //temobool = true;
    }


    public void CreatBall(Vector3 point,BallType ballType, int level)
    {
        counter++;
        switch (ballType)
        {
            case BallType.sword:
                nowBall = Instantiate(swordObj,balls.transform);
                LogSvc.GetInstance().SaveLog2("sword");
                break;
            case BallType.hero:
                nowBall = Instantiate(heroObj, balls.transform);
                LogSvc.GetInstance().SaveLog2("hero");

                break;
            case BallType.fire:

                nowBall = Instantiate(fireObj, balls.transform);
                LogSvc.GetInstance().SaveLog2("fire");

                break;
            case BallType.firesword:
                nowBall = Instantiate(fireSwordObj, balls.transform);
                LogSvc.GetInstance().SaveLog2("firesword");

                break;
            case BallType.water:
                nowBall = Instantiate(waterObj, balls.transform);
                LogSvc.GetInstance().SaveLog2("water");

                break;
            case BallType.watersword:
                nowBall = Instantiate(waterSwordObj, balls.transform);
                LogSvc.GetInstance().SaveLog2("watersword");

                break;
            default:
                break;
        }
        try
        {
            nowBall.transform.position = point;
            nowBall.GetComponent<BallBase>().Init(ballType, level);
        }
        catch
        {
            Debug.Log("AA");
        }
        try
        {

            EventCenter.GetInstance().EventTrigger<int>(EventDic.EnemyAttackCounterReduce,1);
        }
        catch
        {
            Debug.Log("AAA");
        }
        EventCenter.GetInstance().EventTrigger<QuestType>(EventDic.QuestCheack, QuestType.AttackCount);
    }

    public void MixBall(Vector3 point,int level,BallType type)
    {
        if (level + 1 >= maxBall)
        {
            maxBall = level+1;
        }
        EventCenter.GetInstance().EventTrigger<QuestType>(EventDic.QuestCheack, QuestType.MaxBallSize);

        switch (type)
        {
            case BallType.fire:

                var obj = Instantiate(fireSwordObj, balls.transform);
                obj.transform.position = point;
                obj.GetComponent<BallBase>().Init(BallType.firesword, level+1);
                LogSvc.GetInstance().SaveLog2("firesword");

                break;
            case BallType.water:
                var obj2 = Instantiate(waterSwordObj, balls.transform);
                obj2.transform.position = point;
                obj2.GetComponent<BallBase>().Init(BallType.watersword, level+1);
                LogSvc.GetInstance().SaveLog2("watersword");

                break;
            default:
                break;
        }
    }

}
