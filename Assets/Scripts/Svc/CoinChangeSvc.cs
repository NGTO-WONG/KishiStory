using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChangeSvc : BaseManager<CoinChangeSvc>
{
    Queue<string> tipQueue = new Queue<string>();
    public void Show(int changeValue)
    {
        if (UIManager.GetInstance().panelDic.ContainsKey("TopInfos"))
        {
            UIManager.GetInstance().HidePanel("TopInfos");
        }

        UIManager.GetInstance().ShowPanel<TopInfos>("TopInfos", E_UI_Layer.Top, (obj) =>
        {
            obj.Init(changeValue);
        });
    }
}
