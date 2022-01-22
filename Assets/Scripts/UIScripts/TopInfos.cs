using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopInfos : BasePanel
{
    int oldValue;
    int changeValue;
    public void Init(int changeValue)
    {
        oldValue = GameRoot.instance.playerModel.Coin- changeValue;
        this.changeValue = changeValue;
        GetControl<Text>("Text_ChangeValue").text = changeValue.ToString();
        GetControl<Text>("Text_Coin").text = oldValue.ToString();

        if (changeValue == 0)
        {
            GetControl<Text>("Text_ChangeValue").enabled = false;
        }
        Invoke("HideThisCounter", 6f);
    }
    public void HideThisCounter()
    {
        try
        {

            UIManager.GetInstance().HidePanel("TopInfos");
        }
        catch
        {
            Debug.Log("BUG");
        }
        Destroy(this.gameObject);
    }

    public void SetNewCoinValue()
    {
        GetControl<Text>("Text_Coin").text = (oldValue + changeValue).ToString();
    }

    public void HideThis()
    {
        UIManager.GetInstance().HidePanel("TopInfos");
    }
}
