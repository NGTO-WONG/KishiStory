using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSword : BallBase
{
    private void Awake()
    {
        //level = 1;
        //ballType = BallType.sword;
    }
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
                    break;
                case BallType.hero:
                    //Debug.Log("attack");
                    //Destroy(this.gameObject);
                    //Destroy(collision.gameObject);
                    break;
                case BallType.fire:

                    //BallCreator.instance.nowBall = null;
                    Vector3 centerPoint = (transform.position + collision.collider.gameObject.transform.position) / 2f;
                    int newLevel = collision.collider.gameObject.GetComponent<BallBase>().level > this.level ?collision.collider.gameObject.GetComponent<BallBase>().level:this.level;

                    BallCreator.instance.MixBall(centerPoint, newLevel, BallType.fire);
                    Game3BallFXSvc.GetInstance().MixBallFX(GameConfig.ballMixFX, centerPoint, null);

                    //BallCreator.instance.CreatBall(centerPoint, BallType.buffsword, this.level> collision.collider.gameObject.GetComponent<BallBase>().level? this.level: collision.collider.gameObject.GetComponent<BallBase>().level);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    //Debug.Log();
                    break;
                case BallType.water:

                    //BallCreator.instance.nowBall = null;
                    Vector3 centerPoint2= (transform.position + collision.collider.gameObject.transform.position) / 2f;
                    int newLevel2 = collision.collider.gameObject.GetComponent<BallBase>().level > this.level ?collision.collider.gameObject.GetComponent<BallBase>().level:this.level;

                    BallCreator.instance.MixBall(centerPoint2, newLevel2,BallType.water);
                    Game3BallFXSvc.GetInstance().MixBallFX(GameConfig.ballMixFX, centerPoint2, null);

                    //BallCreator.instance.CreatBall(centerPoint, BallType.buffsword, this.level> collision.collider.gameObject.GetComponent<BallBase>().level? this.level: collision.collider.gameObject.GetComponent<BallBase>().level);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                    //Debug.Log();
                    break;
                case BallType.firesword:
                    break;
                default:
                    break;
            }
        }
    }
}
