using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidInfoSetting : MonoBehaviour
{

    public Text level;
    public Text atk;
    public Text def;

    public Text coin;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate, UpdateInfo);
        UpdateInfo();
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener(EventDic.PlayerModelUpdate, UpdateInfo);

    }
    private void UpdateInfo()
    {
        var playerModel = GameRoot.instance.playerModel;
        level.text = playerModel.CharaInfoDic[playerModel.nowCharaName].level.ToString();
        //atk.text = playerModel.CharaInfoDic[playerModel.nowCharaName].atk.ToString();
        //def.text = playerModel.CharaInfoDic[playerModel.nowCharaName].def.ToString();
        atk.text = PlayerModelController.GetInstance().GetPlayerInfo().atk.ToString();
        def.text = PlayerModelController.GetInstance().GetPlayerInfo().def.ToString();
        //try
        //{

        //    Debug.Log(playerModel.eqp_body.level + " " + playerModel.eqp_body.def);
        //}
        //catch { };
        coin.text = playerModel.Coin.ToString();
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
