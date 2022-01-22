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
                name = "ѡ���ɫ";
                //description= "  ����¡λ�ڰ��հ����أ�������Ů����ͳ�Ρ����������Ǵ��֮ĸ����Ҫ��֧��֮�أ���Ҳ���������������������ľ������䡣����Ů��ͨ���������ȴ�Ů���ĳ�Ů�̳У����ȴ�Ů��������������һ�����ʽ�����ڼ仳���������������ʽ������������ЩŮ����������ѡ������ż����ֻ�����������µ�Ů���ܳ�Ϊ��һ������Ů������ˣ�����¡��Ů��ͨ��Ҳ�ǰ��հ�������Ů�����ڶ�����һֱάϵ�������β����Ƶ�Ŧ����\n  ����¡ӵ���ƾõ���ʷ�����Ĵ�ɭ�������о�������������ϵġ����ҵ������������Ź��ϵ�������ͬʱ��Щ��˵�е�����������ˣ���Ů��������Ȼ��������»��������Ȼ���ż��µ�������������������ɢ������������в�����а�����Щ���Ի���ɽ���Ĺ��\n  ����Ů������ͥһֱ�ڰ���¡�Ĵ�Ѳ�ӣ�����һ֧�񻶽ڵ����ж��飬ͣפ֮������֧��˿�������ڰ��磬ɭ���ﶼ������������Ц�������羫������ҫ�Լ��Ŀ��֣���ҹ����Ů֮����ںڰ�����˸�����������ǵĿ񻶺�ʢ�硣";
                description = "";
                break;
            case 2:

                name = "ѡ���ɫ";
                //description = "  ���еľ��鶼��ͬ��һ����һ�����壬��ͬ���������ð�ĺ�����½���հ���Ȼ��������ν�����޲���֮�����ħϮ��ʱ��������ŷͦ����������������ǡ���������ȷʵ��һλ��ӹ���ɵ�Ӣ�ۡ��������γ�����֮������һ������Ҳ�������Լ������塣\n  ��ħ�������𣬴��������ѽ�������ʤ�������������ǵ�ȴ�ǳ��׵ĲҰܡ���Ϊ���ڰ�����ŷһ��ľ�������հ���������������˷��磬ͬ����еı����������Ļ������Ϊ����³�롻�ĺڰ�����һ��Ҳ����ս��Ѫ����ıɱ�н������������ⳡ�������յ�����ǧ��ǰ�ġ�����ѡ���Ȼ�����ⳡ���屯���Ԫ�ײ�����Ȼ��������������Ϊ����Ϊǿ���ͳ����֮һ����������������ĸ�ף���¡�µġ�����Ů�ס�Ī��˿��";
                description = "";
                break;
        }

        GetControl<Text>("Text_name") .text= name;
        GetControl<Text>("Text_description") .text= description;

    }
}
