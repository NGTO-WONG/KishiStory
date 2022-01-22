using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo
{

    public string ballA;
    public string ballASize;
    public string ballB;
    public string ballBSize;




    public int ballLevel;
    public float weight;
    public BallType ballType;
    public AttackInfo(int ballLevel, BallType ballType,string ballA,string ballASize,string ballB, string ballBSize,float weight)
    {
        this.ballLevel = ballLevel;
        this.ballType = ballType;
        this.ballA = ballA;
        this.ballASize = ballASize;
        this.ballB = ballB;
        this.ballBSize = ballBSize;
        this.weight = weight;
    }
}

public class BallHero : BallBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);


        if (collision.collider.tag == "ball")
        {

            switch (collision.collider.gameObject.GetComponent<BallBase>().ballType)
            {
                case BallType.sword:
                    //LogSvc.GetInstance().SaveLog1(ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(), "1", "1");
                    int biggerLevel = collision.collider.GetComponent<BallBase>().level;
                    AttackInfo attackInfo = new AttackInfo(biggerLevel, BallType.sword, ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(),weight);
                    //EventCenter.GetInstance().EventTrigger<BallType>(EventDic.ControllAreaPlayerAttack,BallType.sword) ;
                    Game3BallFXSvc.GetInstance().AttackBallFXWithAttackTrigger(GameConfig.fireSwordAttackFx, gameObject.transform.position, () =>
                     {
                         
                         EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaPlayerAttack,attackInfo) ;

                         Debug.Log("attack");
                     }) ;
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    break;
                case BallType.hero:
                    break;
                case BallType.fire:

                    break;
                case BallType.firesword:

                    Debug.Log("attack2");
                    //EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaPlayerAttack);
                    //LogSvc.GetInstance().SaveLog1(ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(), "1", "2");
                    int biggerLevel2 = collision.collider.GetComponent<BallBase>().level;
                    AttackInfo attackInfo2 = new AttackInfo(biggerLevel2, BallType.firesword, ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(),weight);
                    //EventCenter.GetInstance().EventTrigger<BallType>(EventDic.ControllAreaPlayerAttack,BallType.sword) ;
                    Game3BallFXSvc.GetInstance().AttackBallFXWithAttackTrigger(GameConfig.fireSwordAttackFx, gameObject.transform.position, () =>
                    {
                        
                        EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaPlayerAttack, attackInfo2);

                        Debug.Log("attack");
                    });
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    break;
                case BallType.watersword:

                    Debug.Log("attack3");
                    //EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaPlayerAttack);
                    //LogSvc.GetInstance().SaveLog1(ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(), "1", "3");
                    int biggerLevel3 = collision.collider.GetComponent<BallBase>().level;
                    AttackInfo attackInfo3 = new AttackInfo(biggerLevel3, BallType.watersword, ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(), collision.collider.GetComponent<BallBase>().level.ToString(),weight);
                    //EventCenter.GetInstance().EventTrigger<BallType>(EventDic.ControllAreaPlayerAttack,BallType.sword) ;
                    Game3BallFXSvc.GetInstance().AttackBallFXWithAttackTrigger(GameConfig.fireSwordAttackFx, gameObject.transform.position, () =>
                    {
                        //int biggerLevel = level > collision.collider.GetComponent<BallBase>().level ? level : collision.collider.GetComponent<BallBase>().level;
                        
                        EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaPlayerAttack, attackInfo3);

                        Debug.Log("attack");
                    });
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

}
