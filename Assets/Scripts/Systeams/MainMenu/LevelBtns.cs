using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtns : MonoBehaviour
{


    public static LevelBtns instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //InitBtn();
        EventCenter.GetInstance().AddEventListener<string>(EventDic.MainMenuLevelBtnClick, MainMenuLevelBtnClick);
        //foreach (var item in GameRoot.instance.playerModel.UnlockLevelList)
        //{
        //    Debug.Log(item);
        //}
    }

    private void MainMenuLevelBtnClick(string levelName)
    {
        UIManager.GetInstance().ShowPanel<Panel_LevelNote>("Panel_LevelNote", E_UI_Layer.Top, (obj) =>
        {
            obj.Init(levelName);
        });

        //throw new NotImplementedException();
    }

    private void InitBtn()
    {
        foreach (var item in GameRoot.instance.playerModel.UnlockLevelList)
        {
            switch (item)
            {
                case "1-1":
                    transform.GetChild(0).GetComponent<Button>().interactable=true;
                    break;
                case "1-2":
                    transform.GetChild(1).GetComponent<Button>().interactable=true;
                    break;
                case "1-3":
                    transform.GetChild(2).GetComponent<Button>().interactable=true;
                    break;
                case "1-4":
                    transform.GetChild(3).GetComponent<Button>().interactable=true;
                    break;
                case "1-5":
                    transform.GetChild(4).GetComponent<Button>().interactable=true;
                    break;
            }
        }
        //throw new NotImplementedException();
    }


    // Update is called once per frame
    void Update()
    {
    }
}
