using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Setting : BasePanel
{

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(HideThis);
        GetControl<Button>("Button_Go2MainMenu").onClick.AddListener(Button_Go2MainMenu);
        GetControl<Button>("Button_Back").onClick.AddListener(Button_Back);
    }

    private void Button_Back()
    {
        HideThis();
        //throw new NotImplementedException();
    }

    private void Button_Go2MainMenu()
    {

        SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu", null);
        HideThis();
        //throw new NotImplementedException();
    }

    private void HideThis()
    {
        UIManager.GetInstance().HidePanel("Panel_Setting");
        //throw new NotImplementedException();
    }
}
