using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleAreaMgr : MonoBehaviour
{
    PlayerInfo nowPlayerInfo=null;
    EnemyInfo nowEnemyInfo = null;
    public Transform playerSpawnPoint = null;
    public Transform playerStandPoint = null;
    public Transform enemyStandPoint = null;
    public Transform NextAreaPoint = null;
    public static BattleAreaMgr instance = null;
    void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().Clear();
    }
    public void Init()
    {
        //读取玩家数据
        nowPlayerInfo = BattleSys.GetInstance().playerInfo;
        CreatPlayer();
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerReachedStandPoint, ReadMonsterInfo);


        EventCenter.GetInstance().AddEventListener(EventDic.EnemyDie, EnemyDie);


        //EventCenter.GetInstance().AddEventListener(EventDic.ControllAreaPlayerAttack, PlayerAttack);

        EventCenter.GetInstance().AddEventListener(EventDic.PlayerDie, PlayerDie);


        EventCenter.GetInstance().AddEventListener(EventDic.ControllAreaEnemyAttack, EnemyAttack);

    }

    private void EnemyAttack()
    {
        nowPlayerInfo.GetHit(nowEnemyInfo.atk);
    }

    private void PlayerDie()
    {
        //TODO显示失败UI
        
    }

    private void EnemyDie()
    {
        enemyObj.GetComponent<Animator>().SetBool("die", true);
        enemyObj.GetComponent<Animator>().Play("death");
        PlayerGotoNextArea();
    }

    private void PlayerGotoNextArea()
    {
        //ControlAreaMgr.instance.LockControlArea();
        BGMgr.instance.BGCanMove = true;
        playerObj.GetComponent<Animator>().SetTrigger("run");
        Tweener tweener = playerObj.transform.DOMove(NextAreaPoint.position, 3f);
        tweener.onComplete += () =>
        {
            playerObj.transform.position = playerSpawnPoint.position;
            Tweener tweener2 = playerObj.transform.DOMove(playerStandPoint.position, 3f);
            tweener2.onComplete += () =>
            {
                playerObj.GetComponent<Animator>().SetTrigger("idle");

                EventCenter.GetInstance().EventTrigger(EventDic.PlayerReachedStandPoint);
            };
        };
    }

    private void PlayerAttack()
    {
        nowPlayerInfo.Attack();
        nowEnemyInfo.GetHit(nowPlayerInfo.atk);
    }

    GameObject playerObj = null;
    private void CreatPlayer()
    {
        playerObj =ResMgr.GetInstance().Load<GameObject>(nowPlayerInfo.objPath);
        nowPlayerInfo.obj = playerObj;
        playerObj.transform.position = playerSpawnPoint.position;

        PlayPlayerEnterAnimation();

    }

    private void PlayPlayerEnterAnimation()
    {

        BGMgr.instance.BGCanMove = true;

        nowPlayerInfo.animator.SetBool("Run",true);
        Tweener tweener = nowPlayerInfo.obj.transform.DOMove(playerStandPoint.position, 3f);

        //Tweener tweener = playerObj.transform.DOMove(Vector2.zero, 3f);
        tweener.onComplete += () =>
        {
            EventCenter.GetInstance().EventTrigger(EventDic.PlayerReachedStandPoint);
            nowPlayerInfo.animator.SetBool("Run", false);
        };

        //throw new NotImplementedException();
    }

    private void Start()
    {

        
    }

    private void ReadMonsterInfo()
    {
        BGMgr.instance.BGCanMove = false;

        //读取怪物信息
        nowEnemyInfo = BattleSys.GetInstance().SendNewEnemy();

        if (nowEnemyInfo == null)
        {
            //TODO 关卡完成
            Debug.Log("生成宝箱");
            SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu", null);
        }
        else
        {
            CreatMonster();
            //ControlAreaMgr.instance.UnLockControlArea();
        }


    }

    GameObject enemyObj = null;
    private void CreatMonster()
    {
        enemyObj = ResMgr.GetInstance().Load<GameObject>(nowEnemyInfo.objPath);
        nowEnemyInfo.obj = enemyObj;
        enemyObj.transform.position = enemyStandPoint.position;
        //enemyObj.GetComponent<Animator>().Play("enter");
        nowEnemyInfo.animator.Play("enter");
        Debug.Log("怪物进入动画播放失败");
        //ControlAreaMgr.instance.UnLockControlArea();
        //throw new NotImplementedException();
    }

    private void Update()
    {
    }

}
