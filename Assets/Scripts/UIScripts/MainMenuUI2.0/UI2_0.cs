using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI2_0 : BasePanel
{
    public UI2_0 instance;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    Sprite[] sprites;
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<int>(EventDic.UI2_0InitPage, InitPage);

        //GetControl<Imae>("Test").sprite = ResMgr.GetInstance().Load<SpriteAtlas>("ResImage/UI/MainMenu/worldMaps").GetSprite("beach");
        
        Init();
    }
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<int>(EventDic.UI2_0InitPage, InitPage);
    }



    public void Init()
    {
        sprites = Resources.LoadAll<Sprite>("ResImage/UI/MainMenu/worldMaps");
        InitRLBtn();
        InitPage(0);

        TestBtn();
    }

    private void TestBtn()
    {
        GetControl<Button>("Button_Unlock").onClick.AddListener(() =>
        {
            GameRoot.instance.playerModel.UnlockLevelList.Clear();
            GameRoot.instance.playerModel.UnlockLevelList.Add("1-1");
            GameRoot.instance.playerModel.UnlockLevelList.Add("1-2");
            GameRoot.instance.playerModel.UnlockLevelList.Add("1-3");
            GameRoot.instance.playerModel.UnlockLevelList.Add("1-4");
            GameRoot.instance.playerModel.UnlockLevelList.Add("2-1");
            GameRoot.instance.playerModel.UnlockLevelList.Add("2-2");
            GameRoot.instance.playerModel.UnlockLevelList.Add("2-3");
            GameRoot.instance.playerModel.UnlockLevelList.Add("2-4");
            GameRoot.instance.playerModel.UnlockLevelList.Add("3-1");
            GameRoot.instance.playerModel.UnlockLevelList.Add("3-2");
            GameRoot.instance.playerModel.UnlockLevelList.Add("3-3");
            GameRoot.instance.playerModel.UnlockLevelList.Add("3-4");
            GameRoot.instance.playerModel.UnlockLevelList.Add("4-1");
            GameRoot.instance.playerModel.UnlockLevelList.Add("4-2");
            GameRoot.instance.playerModel.UnlockLevelList.Add("4-3");
            GameRoot.instance.playerModel.UnlockLevelList.Add("4-4");
            GameRoot.instance.playerModel.UnlockLevelList.Add("5-1");
            GameRoot.instance.playerModel.UnlockLevelList.Add("5-2");
            GameRoot.instance.playerModel.UnlockLevelList.Add("5-3");
            GameRoot.instance.playerModel.UnlockLevelList.Add("5-4");

            InitPage(mapsAnimator.GetInteger("Index"));
        });
        //throw new NotImplementedException();
    }

    public Animator mapsAnimator;
    private void InitRLBtn()
    {
        GetControl<Button>("Button_R").onClick.AddListener(() =>
        {
            int tempInt = mapsAnimator.GetInteger("Index");

            if (tempInt <4)
            {

                mapsAnimator.SetInteger("Index", ++tempInt);
                mapsAnimator.SetTrigger("Triiger");

                InitPage(tempInt);
            }

            if (tempInt == 4)
            {
                GameObject.Find("Button_R").GetComponent<Animator>().Play("Disabled");
            }
            else
            {
                GameObject.Find("Button_L").GetComponent<Animator>().Play("Normal");
            }
        });
        GetControl<Button>("Button_L").onClick.AddListener(() =>
        {
            int tempInt = mapsAnimator.GetInteger("Index");
            if (tempInt >0)
            {

                mapsAnimator.SetInteger("Index", --tempInt);
                mapsAnimator.SetTrigger("Triiger");

                InitPage(tempInt);
            }

            if (tempInt == 0)
            {
                GameObject.Find("Button_L").GetComponent<Animator>().Play("Disabled");
            }
            else
            {
                GameObject.Find("Button_R").GetComponent<Animator>().Play("Normal");
            }
        });
    }

    private void InitPage(int index)
    {
        if (index == 0)
        {
            GetControl<Button>("Button_L").gameObject.GetComponent<Animator>().Play("Disabled");
        }
        if (index == 4)
        {
            GetControl<Button>("Button_R").gameObject.GetComponent<Animator>().Play("Disabled");
        }

        //改变展示的背景
        ChangeMap(index);
        //
        //播放UI动画

        InitBtns(index);


        //ShowBtnImages(index);
        
        //GetControl<Image>("Image_MapBorder").sprite=ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/worldMaps")




        //throw new NotImplementedException();
    }

    private void InitBtns(int index)
    {
        var Btns = GameObject.Find("Image_Maps").transform.GetChild(index).GetChild(0);
        Debug.Log(GameObject.Find("Image_Maps").transform.GetChild(index).name);
        for (int i = 0; i < Btns.childCount; i++)
        {
            StartCoroutine(IEBtnInit(i * 0.2f, Btns.GetChild(i).gameObject));
            //Btns.GetChild(i).gameObject.GetComponent<Btn_level2_0>().Init();
        }


        //throw new NotImplementedException();
    }

    IEnumerator IEBtnInit(float t,GameObject obj)
    {
        Debug.Log("s");
        yield return new WaitForSeconds(t);//运行到这，暂停t秒
        obj.GetComponent<Btn_level2_0>().Init();
    }


    //GameObject Btns;
    //private void ShowBtnImages(int index)
    //{
    //    Btns = GameObject.Find("Image_Maps").transform.GetChild(index).gameObject;
    //    for (int i = 0; i < Btns.transform.childCount; i++)
    //    {

    //        StartCoroutine(IEShowBtnImages(i * 0.1f, i));
    //    }

    //}


    //IEnumerator IEShowBtnImages(float t, int index)
    //{

    //    yield return new WaitForSeconds(t);//运行到这，暂停t秒

    //    //t秒后，继续运行下面代码
    //    var tempObj = ResMgr.GetInstance().Load<GameObject>("UI/UIAnimator/MainMenu/BtnStar");
    //    tempObj.transform.SetParent(Btns.transform.GetChild(0).GetChild(index).transform);
    //    tempObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    //    tempObj.transform.localScale = new Vector3(1, 1, 1) * (576f / Screen.width);

    //    int star = PlayerModelController.GetInstance().GetLevelStarDic(Btns.transform.GetChild(index).name);
    //    tempObj.GetComponent<BtnStar>().Init(star);
    //    //print("Time over.");
    //}

    private void ChangeMap(int index)
    {

        //throw new NotImplementedException();
    }
}
