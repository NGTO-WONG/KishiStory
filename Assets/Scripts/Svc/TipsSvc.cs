using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSvc : BaseManager<TipsSvc>
{
    Queue<string> tipQueue = new Queue<string>();
    public void ShowTip(string text)
    {
        if (UIManager.GetInstance().panelDic.ContainsKey("Panel_Tip"))
        {
            UIManager.GetInstance().HidePanel("Panel_Tip");
        }

        UIManager.GetInstance().ShowPanel<Panel_Tip>("Panel_Tip", E_UI_Layer.Top, (obj) =>
        {
            obj.Init(text);
        });
    }
}
