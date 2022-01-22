using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarEnemy : HPBar
{
    public Image weakBallFire;
    public Image weakBallWater;
    public Text enemyAttackCounter;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener<float>(EventDic.EnemyHPBarUpdate, UpdateHPBar);
        EventCenter.GetInstance().AddEventListener<float>(EventDic.InitEnemyHPBar, InitEnemyHPBar);
        //EventCenter.GetInstance().AddEventListener<string>(EventDic.EnemyAttackCounterReduce, EnemyAttackCounterReduce);

        //EventCenter.GetInstance().AddEventListener()

    }

    private void EnemyAttackCounterReduce(string arg0)
    {
        enemyAttackCounter.text = arg0;
        //throw new NotImplementedException();
    }

    public void InitEnemyHPBar(float newHP)
    {
        maxHp = newHP;
        nowHp = maxHp;

        UpdateHPBar(maxHp);
        //Debug.Log(BattleAreaMgr2.instance.nowEnemyInfo.weakBallType);

    }

    protected override void UpdateHPBar(float newHP)
    {
        base.UpdateHPBar(newHP);
        enemyAttackCounter.text = BattleAreaMgr2.instance.nowEnemyInfo.nowAttackCounter.ToString();
        SetEnemyAttackCounter();
        SetWeakBall();

    }

    private void SetEnemyAttackCounter()
    {
        enemyAttackCounter.text = BattleAreaMgr2.instance.nowEnemyInfo.nowAttackCounter.ToString();
        //throw new NotImplementedException();
    }

    private void SetWeakBall()
    {

        try
        {
            switch (BattleAreaMgr2.instance.nowEnemyInfo.weakBallType)
            {
                case BallType.fire:
                    //Debug.Log(BattleAreaMgr2.instance.nowEnemyInfo.weakBallType);
                    weakBallFire.gameObject.SetActive(true);
                    weakBallWater.gameObject.SetActive(false);
                    break;
                case BallType.water:
                    //Debug.Log(BattleAreaMgr2.instance.nowEnemyInfo.weakBallType);
                    weakBallFire.gameObject.SetActive(false);
                    weakBallWater.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        catch
        {
            Debug.LogError("this");
        }
        //throw new NotImplementedException();
    }
}
