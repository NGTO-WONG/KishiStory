using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Panel_LevelNoteInfo
{
    public Sprite Image_SceneImage;
    public string Text_SceneIntroduce;
}

public class Panel_LevelNote : BasePanel
{
    public Button Button_EnterBattleScene;

    public void Init(string levelName)
    {
        SetInfos(levelName);
        SetBtnEvent(levelName);
    }

    private void Start()
    {
        GetControl<Button>("ExitArea").onClick.AddListener(() =>
        {
            GetComponent<Animator>().Play("hide");
            try
            {
                Invoke("HideThis", 2f);

            }
            catch
            {
                Debug.Log("Bug");
            }
        });
    }
    private void SetBtnEvent(string levelName)
    {
        Button_EnterBattleScene.onClick.AddListener(() =>
        {
            List<EnemyInfo> enemyInfos = null;
            LevelAward levelAward = null;
            //GetControl<Button>("Button_EnterBattleScene").gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
            try
            {

                try
                {

                    enemyInfos = GameConfig.GetInstance().GetEnemyInfos(levelName);
                    levelAward = GameConfig.GetInstance().GetAwards(levelName);
                }
                catch
                {
                    Debug.Log("This");
                }
                PlayerInfo playerInfo = PlayerModelController.GetInstance().GetPlayerInfo();
                SceneLoadSvc.GetInstance().LoadSceneWithFX("BattleScene", () =>
                {
                    EventCenter.GetInstance().EventTrigger(EventDic.HideBottomMenu);
                    BattleSys.GetInstance().Init(playerInfo, enemyInfos, levelAward);
                    //HideThis();
                    try
                    {
                        GetComponent<Animator>().Play("hide");
                    }
                    catch
                    {
                        Debug.Log("bug");
                    }
                });
            }
            catch { }

        });
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Button_EnterBattleScene.onClick.Invoke();
        //}
        if(SceneManager.GetActiveScene().name!= "MainMenu")
        {
            HideThis();
            Destroy(this.gameObject);
            Debug.Log("haha");
        }
    }


    public void HideThis()
    {

        UIManager.GetInstance().HidePanel("Panel_LevelNote");
    }
    private void SetInfos(string levelName)
    {
        var info = GameConfig.GetInstance().GetLevelNoteInfo(levelName);
        GetControl<Image>("Image_SceneImage").sprite =info.Image_SceneImage;
        GetControl<Text>("Text_SceneIntroduce").text =info.Text_SceneIntroduce;

        //throw new NotImplementedException();
    }
}
