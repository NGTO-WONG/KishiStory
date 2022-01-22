using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_CharaSelect : BasePanel
{
    public GameObject Chrar1;
    public GameObject Chrar2;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InitBottomBtns();
        //throw new NotImplementedException();
        //ToggleGroup toggleGroup = null;
        UpdateSkillToggleGroup("kokoro3");
        Invoke("T", 0.1f);

    }

    void T()
    {
        if (GameRoot.instance.playerModel.nowCharaName != null)
        {

            if (GameRoot.instance.playerModel.nowCharaName == "kokoro2")
            {

                GetControl<Button>("Button_chara2").onClick.Invoke();
            }
            else
            {

                GetControl<Button>("Button_chara1").onClick.Invoke();
            }
        }
        else
        {

            GetControl<Button>("Button_chara2").onClick.Invoke();
        }
    }
    private void UpdateSkillToggleGroup(string arg0)
    {
        //Debug.Log(GameRoot.instance.playerModel.CharaInfoDic[arg0].SKillNameList.Count);
        //throw new NotImplementedException();
    }

    private void InitBottomBtns()
    {
        GetControl<Button>("EnterMainMenu").onClick.AddListener(() =>
        {
            if (Chrar1.activeSelf == true)
            {

                PlayerModelController.GetInstance().CharaChange("kokoro3");
            }
            else
            {

                PlayerModelController.GetInstance().CharaChange("kokoro2");
            }
        });

        GetControl<Button>("Button_chara1").onClick.AddListener(() =>
        {

            if (SceneManager.GetActiveScene().name != "ReallyChara")
            {

                GetComponent<Animator>().Play("ShowTextBG");
            }
            else
            {
                GetComponent<Animator>().Play("ShowTextBG 1");

            }

            Chrar1.SetActive(true);
            Chrar2.SetActive(false);
            SetTextBG(1);
            SetGroupInfo(1);

            PlayerModelController.GetInstance().CharaChange("kokoro3");
        });

        GetControl<Button>("Button_chara2").onClick.AddListener(() =>
        {
            //PlayerModelController.GetInstance().CharaChange("kokoro3");

            if (SceneManager.GetActiveScene().name != "ReallyChara")
            {

                GetComponent<Animator>().Play("ShowTextBG");
            }
            else
            {
                GetComponent<Animator>().Play("ShowTextBG 1");

            }
            Chrar1.SetActive(false);
            Chrar2.SetActive(true);
            SetGroupInfo(2);
            SetTextBG(2);

            PlayerModelController.GetInstance().CharaChange("kokoro2");
        });
        //throw new NotImplementedException();
    }

    private void SetGroupInfo(int v)
    {
        try
        {

            var model = GameRoot.instance.playerModel.CharaInfoDic["kokoro2"];
            switch (v)
            {
                case 1:
                    model = GameRoot.instance.playerModel.CharaInfoDic["kokoro3"];
                    break;
                case 2:
                    model = GameRoot.instance.playerModel.CharaInfoDic["kokoro2"];
                    break;
                default:
                    break;
            }
            GetControl<Text>("Text_Level").text = model.level.ToString();
            GetControl<Text>("Text_ATK").text = model.atk.ToString();
            GetControl<Text>("Text_DEF").text = model.def.ToString();
            GetControl<Text>("Text_HP").text = model.hp.ToString();
        }
        catch
        {
            Debug.Log("bug");
        }
        //throw new NotImplementedException();
    }

    private void SetTextBG(int charaIndex)
    {
        string name="";
        string description = "";
        switch (charaIndex)
        {
            case 1:
                name = "选择角色";
                //description= "  阿瓦隆位于奥苏安腹地，由永恒女王所统治。她的王国是大地之母最重要的支配之地，她也被视作是整个精灵王国的精神领袖。永恒女王通常都会由先代女王的长女继承，是先代女王在与凤凰王长达一年的仪式婚姻期间怀孕所生。在这段形式婚姻结束后，这些女王可以自由选择新配偶，但只有与凤凰王生下的女儿能成为下一任永恒女王。因此，阿瓦隆的女王通常也是奥苏安的永恒女王，在多年来一直维系着这条牢不可破的纽带。\n  阿瓦隆拥有悠久的历史，它的大森林是所有精灵王国中最古老的。杂乱的树丛中隐藏着古老的魅力，同时那些传说中的生物，包括树人，仙女和树妖仍然在其荫庇下活动。这里虽然有着极致的美丽，但对入侵者则散发着致命的威胁，其中包括那些来自环形山脉的怪物。\n  永恒女王的王庭一直在阿瓦隆四处巡视，犹如一支狂欢节的游行队伍，停驻之处都会支起丝绸帐篷。在白昼，森林里都会响起银铃般的笑声，犹如精灵在炫耀自己的快乐；在夜晚，仙女之光会在黑暗中闪烁，照亮着他们的狂欢和盛宴。";
                description = "";
                break;
            case 2:

                name = "选择角色";
                //description = "  所有的精灵都曾同属一个单一的种族，共同生活在天堂般的海岛大陆奥苏安。然而，正所谓世间无不破之物。当恶魔袭来时，艾纳瑞欧挺身而出并击败了他们。此人起先确实是一位毋庸置疑的英雄…但从他拔出凯恩之剑的那一刻起，他也毁灭了自己的亲族。\n  恶魔虽已消灭，大漩涡虽已建立，但胜利所带给精灵们的却是彻底的惨败。最为忠于艾纳瑞欧一族的精灵与奥苏安的其他精灵产生了分歧，同族相残的悲剧拉开了帷幕，被称为『杜鲁齐』的黑暗精灵一族也就在战火、血腥与谋杀中建立了起来。这场悲剧最终导致了千年前的『大分裂』，然而，这场种族悲剧的元凶不仅仍然在世，甚至还成为了最为强大的统治者之一！她，便是巫王的母亲，戈隆德的『至高女巫』莫拉丝！";
                description = "";
                break;
        }

        GetControl<Text>("Text_name") .text= name;
        GetControl<Text>("Text_description") .text= description;

    }
}
