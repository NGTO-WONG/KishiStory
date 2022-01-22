using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPlayer : HPBar
{
    // Start is called before the first frame update
    void Start()
    {

        EventCenter.GetInstance().AddEventListener<float>(EventDic.InitPlayerHPBar, InitPlayerHPBar);
        EventCenter.GetInstance().AddEventListener<float>(EventDic.PlayerHPBarUpdate, UpdateHPBar);
    }
    public void InitPlayerHPBar(float newHP)
    {
        maxHp = newHP;
        nowHp = maxHp;
        UpdateHPBar(maxHp);

    }
}
