using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BallType
{
    sword,
    hero,
    fire,
    firesword,
    water,
    watersword,
}



public class BallBase : MonoBehaviour
{
    public int level;
    public BallType ballType;
    public float weight;

    public void Init(BallType _ballType,int _level)
    {
        level = _level;
        ballType = _ballType;
        weight = 1f;
        try
        {

            weight = GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_level == _level).weighted;
        }
        catch { }
        float tempValue = 1f;
        try
        {
            tempValue=(float)GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_level == _level).fruit_size / 80.0f;
            Debug.Log("this" + tempValue);
        }
        catch 
        {
            Debug.Log("this2" + tempValue);
        }
        SetLevelImage(_level);
        transform.localScale *=tempValue;
        
    }

    private void SetLevelImage(int level)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        try
        {
            transform.GetChild(level - 1).gameObject.SetActive(true);
        }
        catch
        {
            Debug.Log(level-1);
        }
        //throw new NotImplementedException();
    }

    private void Start()
    {

    }
    protected void PlayFX(string FXName,Vector3 point)
    {

        Game3BallFXSvc.GetInstance().MixBallFX(GameConfig.ballMixFX, point, null);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ball")
        {
            if ((ballType == collision.collider.gameObject.GetComponent<BallBase>().ballType) && (level == collision.collider.gameObject.GetComponent<BallBase>().level)&& !(ballType==BallType.hero&& collision.collider.GetComponent<BallBase>().ballType==BallType.hero) )
            {
                LogSvc.GetInstance().SaveLog1(ballType.ToString(), level.ToString(), collision.collider.GetComponent<BallBase>().ballType.ToString(),collision.collider.GetComponent<BallBase>().level.ToString(), "0", "0");
                Vector3 centerPoint = (transform.position + collision.collider.gameObject.transform.position) / 2f;
                Game3BallFXSvc.GetInstance().MixBallFX(GameConfig.ballMixFX, centerPoint, null);

                //Destroy(this.gameObject);
                Destroy(collision.gameObject);  
                level++;
                if (level >= BallCreator.instance.ballSizeMax)
                {
                    BallCreator.instance.ballSizeMax = level;
                }
                EventCenter.GetInstance().EventTrigger<QuestType>(EventDic.QuestCheack, QuestType.MaxBallSize);

                float tempValue = 1f;
                try
                {
                    tempValue = (float)GameConfig.GetInstance().GameConfig_fruitList.Find(x => x.fruit_level == level).fruit_size/80.0f;
                    Debug.Log(tempValue);
                }
                catch { }
                transform.localScale *= tempValue;

                SetLevelImage(level);
            }

        }

    }
}
