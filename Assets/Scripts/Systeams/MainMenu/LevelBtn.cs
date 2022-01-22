using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Button>().onClick.AddListener(EnterBattleArea); //11111
        GetComponent<Button>().onClick.AddListener(BtnClick);
    }

    private void BtnClick()
    {
        EventCenter.GetInstance().EventTrigger<string>(EventDic.MainMenuLevelBtnClick, gameObject.name);
        //throw new NotImplementedException();
    }

    public void Init(string _levelName)
    {
        this.levelName = _levelName;
        SetStar();

    }

    private void SetStar()
    {
        //throw new NotImplementedException();
    }

    private void EnterBattleArea()
    {
        //string levelName=null;
        List<EnemyInfo> enemyInfos = null;
        LevelAward levelAward = null;

        switch (transform.GetSiblingIndex())
        {
            case 0:
                enemyInfos = GameConfig.GetInstance().GetEnemyInfos("1-1");
                levelAward = GameConfig.GetInstance().GetAwards("1-1");
                break;
            case 1:
                enemyInfos = GameConfig.GetInstance().GetEnemyInfos("1-2");
                levelAward = GameConfig.GetInstance().GetAwards("1-2");

                break;
            case 2:
                enemyInfos = GameConfig.GetInstance().GetEnemyInfos("1-3");
                levelAward = GameConfig.GetInstance().GetAwards("1-3");
                break;
            case 3:
                enemyInfos = GameConfig.GetInstance().GetEnemyInfos("1-4");
                levelAward = GameConfig.GetInstance().GetAwards("1-4");
                break;
        }
        PlayerInfo playerInfo = PlayerModelController.GetInstance().GetPlayerInfo();


        SceneLoadSvc.GetInstance().LoadSceneWithFX("BattleScene", () =>
        {
            BattleSys.GetInstance().Init(playerInfo, enemyInfos, levelAward);
        });
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
