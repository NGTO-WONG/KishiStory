using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleSys : BaseManager<BattleSys>
{
    public PlayerInfo playerInfo;
    public  List<EnemyInfo> enemyInfos;
    public LevelAward levelAward;
    public int star;


    public   List<Quest> questList;
    //public List<string> questStringArray = new List<string>(){"1","2","3"};



    //public static BattleSys instance;
    /// <summary>
    /// /进入场景
    /// </summary>
    /// <param name="arg0"></param>
    /// <param name="arg1"></param>
    public void Init(PlayerInfo arg0, List<EnemyInfo> arg1, LevelAward arg2)
    {
        //设置玩家,怪物数据
        
        playerInfo = arg0;
        enemyInfos = arg1;
        levelAward = arg2;
        star = 0;
        BattleAreaMgr2.instance.Init();
        ControlAreaMgr.instance.Init();
        EventCenter.GetInstance().AddEventListener(EventDic.LevelClear,LevelClear);
        EventCenter.GetInstance().AddEventListener(EventDic.BattleSysStarAdd, StarAdd);
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerDie,LevelFailed);

        questList = new List<Quest>();

        foreach (var item in GameConfig.GetInstance().GetQuestCondition(levelAward.levelName))
        {
            questList.Add(item);
            Debug.Log(item.describe+" " +item.isDone.ToString()+" "+item.questType);
        }
        EventCenter.GetInstance().AddEventListener<QuestType>(EventDic.QuestCheack, QuestCheack);

    }

    public void LevelFailed()
    {
        ControlAreaMgr.instance.LockControlArea();
        UIManager.GetInstance().ShowPanel<Panel_LevelFailed>("Panel_LevelFailed",E_UI_Layer.Top);
    }

    private void QuestCheack(QuestType arg0)
    {
        switch (arg0)
        {
            case QuestType.AttackCount:
                var tempQuest=questList.Find(x => x.questType == QuestType.AttackCount);
                tempQuest.attackCounter++;
                Debug.Log("attackCounter:" + tempQuest.attackCounter);
                if (tempQuest.attackCounter <= tempQuest.targetNumber)
                {
                    tempQuest.isDone = true;
                }
                else
                {

                    tempQuest.isDone = false;
                }
                break;
            case QuestType.PlayerHpLeft:
                var tempQuest2 = questList.Find(x => x.questType == QuestType.PlayerHpLeft);

                if (tempQuest2.targetNumber <= BattleAreaMgr2.instance.nowPlayerInfo.hp)
                {
                    Debug.Log("quest2" + tempQuest2.targetNumber + " " + BattleAreaMgr2.instance.nowPlayerInfo.hp + " done");
                    tempQuest2.isDone = true;
                }
                else
                {
                    tempQuest2.isDone = false;

                }
                break;
            case QuestType.MaxBallSize:
                var tempQuest3 = questList.Find(x => x.questType == QuestType.MaxBallSize);
                Debug.Log("quest3:"+BallCreator.instance.maxBall);
                if (tempQuest3.targetNumber <= BallCreator.instance.maxBall)
                {
                    tempQuest3.isDone = true;
                }
                else
                {
                    tempQuest3.isDone = false;

                }
                break;
            default:
                break;
        }

        //throw new NotImplementedException();
    }

    private void StarAdd()

    {
        star += 1;
        //throw new NotImplementedException();
    }

    private void LevelClear()
    {
        //添加clearList
        PlayerModelController.GetInstance().LevelClear(levelAward.levelName);

        //添加回报 
        //装备 金币 经验
        foreach (Equipment item in levelAward.awardEqpList) 
        {
            PlayerModelController.GetInstance().GetNewEqp(item);
        }
        //CoinChangeSvc.GetInstance().Show(levelAward.awardCoin);
        PlayerModelController.GetInstance().GetCoin(levelAward.awardCoin);
        //PlayerModelController.GetInstance().GetCoin(levelAward.awardCoin);
        PlayerModelController.GetInstance().LevelUp(levelAward.awardLevelNum);
        foreach (var item in questList)
        {
            Debug.Log(item.isDone);
            if (item.isDone)
            {
                star++;
            }
        }
        PlayerModelController.GetInstance().SetLevelStarDic(levelAward.levelName, star >= 3 ? 3 : star);
        Debug.Log(star);
        Debug.Log(GameRoot.instance.playerModel.LevelStartDic["1-1"]);
        //throw new NotImplementedException();
    }

    // Start is called before the first frame update

    public EnemyInfo SendNewEnemy()
    {

        if (enemyInfos.Count != 0)
        {
            var tempInfo = enemyInfos[0];
            enemyInfos.RemoveAt(0);
            return tempInfo;
        }
        else
        {
            return null;
        }
    }

}
