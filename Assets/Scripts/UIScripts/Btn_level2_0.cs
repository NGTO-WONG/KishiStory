using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_level2_0 : BasePanel
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<Button>().onClick.AddListener(BtnClick);
    }

    private void BtnClick()
    {
        EventCenter.GetInstance().EventTrigger<string>(EventDic.MainMenuLevelBtnClick, gameObject.name);
        //throw new NotImplementedException();
    }


    public void Init()
    {

        Debug.Log("b");
        animator.Play("Enter");

        GetControl<Text>("Text_Level").text = this.gameObject.name;
        bool useAble = GameRoot.instance.playerModel.UnlockLevelList.Contains(this.gameObject.name);



        if (!useAble)
        {
            GetComponent<CanvasGroup>().alpha = 0.5f;
            GetComponent<Button>().interactable = false;
        }
        else
        {

            GetComponent<CanvasGroup>().alpha = 1f;
            GetComponent<Button>().interactable = true;
        }

        SetStart();
    }

    public GameObject Stars;
    private void SetStart()
    {
        int tempInt = PlayerModelController.GetInstance().GetLevelStarDic(this.gameObject.name);
        for (int i = 0; i < tempInt; i++)
        {
            Stars.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
