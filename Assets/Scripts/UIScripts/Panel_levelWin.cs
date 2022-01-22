using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Panel_levelWin : BasePanel
{
    Animator animator;
    AnimatorStateInfo animatorStateInfo;
    bool overBool = true;
    bool overBool2 = true;
    UnityAction _WhenHidePlayOver;
    UnityAction _WhenShowPlayOver;
    Button Button_backToMainMenu;


    LevelAward _levelAward;
    public GameObject grid;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Button_backToMainMenu = GetControl<Button>("Button_backToMainMenu");



        Button_backToMainMenu.onClick.AddListener(BackToMainMenu);

        Invoke("SetQuest", 0.1f);
    }

    private void BackToMainMenu()
    {

        PlayHide();

        _WhenHidePlayOver = () => { SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu"); };
        //throw new NotImplementedException();
    }

    void PlayHide()
    {
        animator.SetTrigger("hide");
    }
    //GameConfig
    public void Init(UnityAction WhenHidePlayOver=null)
    {
        _WhenShowPlayOver += ()=>{ };
        _WhenHidePlayOver += () => { };

        try
        {
            _levelAward = BattleSys.GetInstance().levelAward;
        }
        catch
        {
            Debug.Log("宝箱回报初始化失败");
        }
        SetAwardImage();
        SetCoinAndExp();
        _WhenHidePlayOver += WhenHidePlayOver;



        //SetQuest();
        
    }
    List<Quest> tempQuestList;
    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;
    public Text quest1text;
    public Text quest2text;
    public Text quest3text;
    public void SetQuest()
    {



        tempQuestList = BattleSys.GetInstance().questList;

        //Invoke("TTT", 1f);


        //完成
        var tempBool = tempQuestList[0].isDone;
        quest1.SetActive(tempQuestList[0].isDone);
        quest2.SetActive(tempQuestList[1].isDone);
        quest3.SetActive(tempQuestList[2].isDone);

        //文字
        quest1text.text = tempQuestList[0].describe;
        quest2text.text = tempQuestList[1].describe;
        quest3text.text = tempQuestList[2].describe;


        //throw new NotImplementedException();
    }


    void TTT()
    {


    }

    private void SetCoinAndExp()
    {
        GetControl<Text>("Text_coin").text = _levelAward.awardCoin.ToString();
        GetControl<Text>("Text_exp").text = (_levelAward.awardLevelNum).ToString();
        //throw new NotImplementedException();
    }

    private void SetAwardImage()
    {

        for (int i = 2; i < _levelAward.awardEqpList.Count+2; i++)
        {
            grid.transform.GetChild(i).gameObject.SetActive(true);
            grid.transform.GetChild(i).GetComponent<Image>().sprite = ResMgr.GetInstance().Load<Sprite>(_levelAward.awardEqpList[i - 2].imagePath);
        }

        int tempInt = _levelAward.awardEqpList.Count+2;
        if (tempInt <= 4)
        {
            tempInt = 0;
        }
        else
        {
            tempInt -= 4;
        }
        grid.GetComponent<RectTransform>().sizeDelta = new Vector2(692f + (173f * tempInt), grid.GetComponent<RectTransform>().sizeDelta.y);
        //throw new NotImplementedException();
    }


    public void ShowGetCoin()
    {
        //CoinChangeSvc.GetInstance().Show(BattleSys.GetInstance().levelAward.awardCoin);
    }
    private void Update()
    {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("hide") && animatorStateInfo.normalizedTime >=0.8f&&overBool)
        {
            Debug.Log("Hideover");
            overBool = false;
            _WhenHidePlayOver.Invoke();
            UIManager.GetInstance().HidePanel("Panel_levelWin");
        }
        if (animatorStateInfo.IsName("playing")&&overBool2)
        {
            Debug.Log("playing");
            overBool2 = false;
            try
            {

                _WhenShowPlayOver.Invoke();
            }
            catch
            {

            }
        }
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("next");
        }
    }
}
