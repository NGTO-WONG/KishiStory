using DG.Tweening;
using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAreaMgr2 : MonoBehaviour
{
    public static BattleAreaMgr2 instance;

    public Transform PlayerSpawnPoint;
    public Transform EnemySpawnPoint;
    public Transform PlayerStandPoint;
    public Transform NextAreaPoint;
    public Transform PlayerAttackPoint;

    public float playerHp;
    public float enemyHp;


    public List<GameObject> EnvList;
    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().Clear();
    }

    public PlayerInfo nowPlayerInfo;
    public EnemyInfo nowEnemyInfo;
    public void Init()
    {
        nowPlayerInfo = BattleSys.GetInstance().playerInfo;

        //CreatPlayer();

        Invoke("CreatPlayer", 2.5f);
        EventCenter.GetInstance().AddEventListener(EventDic.ControllAreaEnemyAttack, EnemyAttack);
        EventCenter.GetInstance().AddEventListener<AttackInfo>(EventDic.ControllAreaPlayerAttack, PlayerAttack);

        EventCenter.GetInstance().AddEventListener(EventDic.PlayerDie, PlayerDie);
        EventCenter.GetInstance().AddEventListener(EventDic.EnemyDie, EnemyDie);

        EventCenter.GetInstance().AddEventListener(EventDic.PlayerReachedStandPoint, PlayerReachedStandPoint);

        EventCenter.GetInstance().AddEventListener<int>(EventDic.EnemyAttackCounterReduce, EnemyAttackCounterReduce);

        SetEnvBackGround();
        //EventCenter.GetInstance().AddEventListener(EventDic.EnemyHitAnimation,nowEnemyInfo.);

    }

    private void SetEnvBackGround()
    {
        string levelName = BattleSys.GetInstance().levelAward.levelName;
        ResMgr.GetInstance().LoadAsync<GameObject>(GameConfig.GetInstance().GetEnvPath(levelName),(obj)=>
        {
            obj.transform.SetParent(this.transform);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
        });
        //throw new NotImplementedException();
    }

    private void EnemyAttackCounterReduce(int arg0)
    {
        nowEnemyInfo.nowAttackCounter -= arg0;
        if (nowEnemyInfo.nowAttackCounter <= 0)
        {
            EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaEnemyAttack);
            nowEnemyInfo.nowAttackCounter = nowEnemyInfo.attackCounter;
        }


        EventCenter.GetInstance().EventTrigger<float>(EventDic.EnemyHPBarUpdate, nowEnemyInfo.hp);
        //EventCenter.GetInstance().EventTrigger<EnemyInfo>()
        //throw new NotImplementedException();
    }

    private void Update()
    {
        try
        {
            //Debug.Log(nowPlayerInfo.atk);
            //Debug.Log(nowEnemyInfo.hp);
            playerHp = nowPlayerInfo.hp;
            enemyHp = nowEnemyInfo.hp;
        }
        catch { };


        if (Input.GetKeyDown(KeyCode.P))
        {

            foreach (var item in BattleSys.GetInstance().questList)
            {
                Debug.Log("B" + item.questType);

            }
        }
    }

    private void PlayerReachedStandPoint()
    {
        nowPlayerInfo.StopRun();
        CreatNextMonsterOrLevelClear();
        EventCenter.GetInstance().EventTrigger(EventDic.BGMoveAbleChange);
        //throw new NotImplementedException();
    }

    private void CreatNextMonsterOrLevelClear()
    {
        nowEnemyInfo = BattleSys.GetInstance().SendNewEnemy();
        if (nowEnemyInfo == null)
        {
            //todo关卡完成
            CreatAwardBox();
            nowPlayerInfo.Win();
        }
        else
        {
            
            nowEnemyInfo.obj = ResMgr.GetInstance().Load<GameObject>(nowEnemyInfo.objPath);
            nowEnemyInfo.obj.transform.position = EnemySpawnPoint.position;
            nowEnemyInfo.animator = nowEnemyInfo.obj.GetComponent<Animator>();
            ControlAreaMgr.instance.UnLockControlArea(); 
            EventCenter.GetInstance().EventTrigger<float>(EventDic.InitEnemyHPBar,nowEnemyInfo.hp);
        }

        Debug.Log(nowEnemyInfo.objPath);
        Debug.Log(nowEnemyInfo.obj.name);
        nowEnemyInfo.obj.GetComponent<DialogueSystemTrigger>().barkText = nowEnemyInfo.enterWord;
        //throw new NotImplementedException();
    }

    private void CreatAwardBox()
    {

        Debug.Log("创建宝箱");

        EventCenter.GetInstance().EventTrigger(EventDic.BGMoveAbleChange);
        var obj= ResMgr.GetInstance().Load<GameObject>("ResObj/other/baoxiang/baoxiang");
        obj.transform.position = EnemySpawnPoint.position;
        EventCenter.GetInstance().EventTrigger<QuestType>(EventDic.QuestCheack, QuestType.PlayerHpLeft);

        Invoke("ShowWinPanel", 1.5f );
        //throw new NotImplementedException();
    }
    
    void ShowWinPanel()
    {
        UIManager.GetInstance().ShowPanel<Panel_levelWin>("Panel_levelWin",E_UI_Layer.Top,(obj)=>
        {
            obj.Init();
        });
        EventCenter.GetInstance().EventTrigger(EventDic.LevelClear);
    }

    private void EnemyDie()
    {
        
        PlayPlayerEnterNextAreaAnimation();
        EventCenter.GetInstance().EventTrigger(EventDic.Game2Change);
        //throw new NotImplementedException();
    }

    private void PlayPlayerEnterNextAreaAnimation()
    {
        ControlAreaMgr.instance.LockControlArea();
        //quence = DOTween.Sequence();
        ControlAreaMgr.instance.LockControlArea(); //lockcon
        nowPlayerInfo.Run();
        EventCenter.GetInstance().EventTrigger(EventDic.BGMoveAbleChange);

        Tweener tweener = nowPlayerInfo.obj.transform.DOMove(NextAreaPoint.position, 3f);
        

        tweener.onComplete += () => 
        {
            nowPlayerInfo.obj.transform.position = PlayerSpawnPoint.position;
            PlayPlayerEnterAnimation();
            EventCenter.GetInstance().EventTrigger(EventDic.BGMoveAbleChange);

            nowPlayerInfo.StopRun();
            ControlAreaMgr.instance.UnLockControlArea();

        };
        //quence.Append(tweener);


        //throw new NotImplementedException();
    }

    private void PlayerDie()
    {
        //Debug.Log("Die");
        //EventCenter.GetInstance().EventTrigger(EventDic.PlayerDie);
        //throw new NotImplementedException();
    }
    Sequence quence;
    private void PlayerAttack(AttackInfo attackInfo)
    {
        if (nowPlayerInfo.obj.GetComponent<Animator>().GetBool("die") == false)
        {

            var atk = nowPlayerInfo.atk;//buff
            EventCenter.GetInstance().EventTrigger<QuestType>(EventDic.QuestCheack, QuestType.AttackCount);

            nowPlayerInfo.Run();
            quence = DOTween.Sequence();
            Tweener tweener = nowPlayerInfo.obj.transform.DOMove(PlayerAttackPoint.position, 1f);
            //Tweener tweener2 = nowPlayerInfo.obj.transform.DOMove(nowPlayerInfo.obj.transform.position, 1f);
            Tweener tweener2 = nowPlayerInfo.obj.transform.DOMove(PlayerStandPoint.position, 1f);
            tweener.onComplete += () =>
            {

                nowPlayerInfo.StopRun();
                nowPlayerInfo.Attack();
                nowEnemyInfo.GetHit(atk, attackInfo);
                EventCenter.GetInstance().EventTrigger<float>(EventDic.EnemyHPBarUpdate, nowEnemyInfo.hp);
                //Debug.Log(nowEnemyInfo.hp);

            };
            //tweener2.onComplete += () => { nowPlayerInfo.obj.transform.DOMove(PlayerStandPoint.position, 0.5f,false); };
            quence.Append(tweener);
            quence.AppendInterval(1);
            quence.Append(tweener2);
        }


        //quence.AppendInterval(1);
        //nowPlayerInfo.StopRun();
        //throw new NotImplementedException();
    }

    private void EnemyAttack()
    {
        nowPlayerInfo.GetHit(nowEnemyInfo.atk);
        EventCenter.GetInstance().EventTrigger<float>(EventDic.PlayerHPBarUpdate, nowPlayerInfo.hp);

        nowEnemyInfo.Attack();
        //throw new NotImplementedException();
    }


    private void Start()
    {


        //Invoke("ttt", 3f);
        //Debug.Log(BattleSys.GetInstance().questList[0].describe);
        //var list = BattleSys.GetInstance().questList;

    }

    void ttt()
    {

        //foreach (var item in BattleSys.questList)
        //{
        //    Debug.Log(item.questType + " " + item.targetNumber);
        //}
    }
    private void CreatPlayer()
    {
        nowPlayerInfo.obj=  ResMgr.GetInstance().Load<GameObject>(nowPlayerInfo.objPath);
        nowPlayerInfo.animator = nowPlayerInfo.obj.GetComponent<Animator>();
        nowPlayerInfo.obj.transform.position = PlayerSpawnPoint.position;
        PlayPlayerEnterAnimation();
        EventCenter.GetInstance().EventTrigger<float>(EventDic.InitPlayerHPBar, nowPlayerInfo.hp);

        //throw new NotImplementedException();
    }

    private void PlayPlayerEnterAnimation()
    {
        nowPlayerInfo.Run();
        EventCenter.GetInstance().EventTrigger(EventDic.BGMoveAbleChange);

        Tweener tweener = nowPlayerInfo.obj.transform.DOMove(PlayerStandPoint.position, 3f);

        tweener.onComplete += () => { EventCenter.GetInstance().EventTrigger(EventDic.PlayerReachedStandPoint); };


        //throw new NotImplementedException();
    }
}
