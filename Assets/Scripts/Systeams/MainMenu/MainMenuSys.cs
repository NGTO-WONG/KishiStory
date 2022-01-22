using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class MainMenuSys : MonoBehaviour
{
    public GameObject Btns;
    public static MainMenuSys instance;
    public GameObject Image_newestLevelNoteObj;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        var t = GameRoot.instance.playerModel.equipmentList.ToList();
        //foreach (var item in GameRoot.instance.playerModel.LevelStartDic)
        //{
        //    Debug.Log(item.Key+" "+item.Value+"最大关卡");
        //}



        try
        {
            GameObject.Find("Image_Adventy").GetComponent<Animator>().Play("Selected");
            GameObject.Find("Image_illustrated").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_Eqp").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_Chara").GetComponent<Animator>().Play("Normal");
        }
        catch
        {
            Debug.Log("bottomBtnsError");
        }



        SetBGM();

        //1
        //ShowBtnImages();
        //SetNewestLevelNote();
        //1
    }

    private void SetNewestLevelNote()
    {
        var btnNewestLevel = GameObject.Find(GameRoot.instance.playerModel.UnlockLevelList[GameRoot.instance.playerModel.UnlockLevelList.Count - 1].ToString());
        Image_newestLevelNoteObj.transform.position = btnNewestLevel.transform.position+(new Vector3(0,130,0) * (576f / Screen.width));
        btnNewestLevel.transform.localScale = new Vector3(1, 1, 1) * (576f / Screen.width);
        Debug.Log("最新关卡:" + GameRoot.instance.playerModel.UnlockLevelList[GameRoot.instance.playerModel.UnlockLevelList.Count - 1]);

        //throw new NotImplementedException();
    }

    private void SetBGM()
    {
        MusicMgr.GetInstance().PlayBkMusic("mainMenu");
        MusicMgr.GetInstance().ChangeBKValue(0.6f);
        //throw new NotImplementedException();
    }

    private void ShowBtnImages()
    {
        for (int i = 0; i < Btns.transform.childCount; i++)
        {

            StartCoroutine(IEShowBtnImages(i*0.1f,i));
        }

    }


    IEnumerator IEShowBtnImages(float t,int index)
    {

        yield return new WaitForSeconds(t);//运行到这，暂停t秒

        //t秒后，继续运行下面代码
        var tempObj = ResMgr.GetInstance().Load<GameObject>("UI/UIAnimator/MainMenu/BtnStar");
        tempObj.transform.SetParent(Btns.transform.GetChild(index));
        tempObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        tempObj.transform.localScale = new Vector3(1, 1, 1) * (576f / Screen.width);

        int star = PlayerModelController.GetInstance().GetLevelStarDic(Btns.transform.GetChild(index).name);
        tempObj.GetComponent<BtnStar>().Init(star);
        //print("Time over.");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
