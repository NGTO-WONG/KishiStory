using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Tip : BasePanel
{
    public void Init(string text)
    {
        GetControl<Text>("Text_info").text = text;
        gameObject.GetComponent<Animator>().Play("show");
    }
    public void HideThis()
    {
        UIManager.GetInstance().HidePanel("Panel_Tip");
    }
}
