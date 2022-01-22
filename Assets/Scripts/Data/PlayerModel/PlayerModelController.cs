using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class PlayerModelController:BaseManager<PlayerModelController>
{
    public void Init()
    {
        InitPlayerModel();
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate, SavePlayerModel);
    }
    public void GetNewEqp(Equipment equipment)
    {
        GameRoot.instance.playerModel.equipmentList.Add(equipment);
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);

    }
    public void GetCoin(int coinNum)
    {
        CoinChangeSvc.GetInstance().Show(coinNum);
        GameRoot.instance.playerModel.Coin += coinNum;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        EventCenter.GetInstance().EventTrigger<int>(EventDic.CoinValueChange, coinNum);
    }
    public bool GetCoinBool(int coinNum)
    {
        if(GameRoot.instance.playerModel.Coin + coinNum < 0)
        {
            return false;
        }
        GetCoin(coinNum);
        return true;
    }

    public void LevelUp(int num)
    {
        
        
        
        var chara = GameRoot.instance.playerModel.CharaInfoDic[GameRoot.instance.playerModel.nowCharaName];
        chara.exp += num;
        chara.level = LevelCounter();
        chara.atk = chara.atk + chara.level * GameConfig.levelIncrease_atk;
        chara.def = chara.def + chara.level * GameConfig.levelIncrease_def;
        chara.hp = chara.hp + chara.level * GameConfig.levelIncrease_hp;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }

    private int LevelCounter()
    {

        var exp = GameRoot.instance.playerModel.CharaInfoDic[GameRoot.instance.playerModel.nowCharaName].exp;
        //chara.exp += num;
        for (int i = 0; i < GameConfig.exp2LevelList.Count; i++)
        {
            if (GameConfig.exp2LevelList[i] > exp)
            {
                return i+1;
            }
        }
        return 1;
        //throw new NotImplementedException();
    }

    public void Eqp_defense(Equipment eqp)
    {
        GameRoot.instance.playerModel.eqp_defense= eqp;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }
    public void Eqp_decorate(Equipment eqp)
    {
        GameRoot.instance.playerModel.eqp_decorate = eqp;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }
    public void Eqp_weapon(Equipment eqp)
    {
        GameRoot.instance.playerModel.eqp_weapon = eqp;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }
    public void Eqp_other(Equipment eqp)
    {
        GameRoot.instance.playerModel.eqp_other = eqp;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }

    public void LevelClear(string levelName)
    {
        string[] tempStr = levelName.Split('-');

        //关卡增加后改我


        string newStr;
        if (tempStr[1] == "4")
        {
            newStr = (Convert.ToInt32(tempStr[0]) + 1).ToString() + "-1";
        }
        else
        {
            newStr = tempStr[0] + "-" + (Convert.ToInt32(tempStr[1]) + 1).ToString();
        }




        //关卡增加后改我



        var tempUnlockList = GameRoot.instance.playerModel.UnlockLevelList;
        if (tempUnlockList.Contains(newStr))
        {

        }
        else
        {

        }
        GameRoot.instance.playerModel.UnlockLevelList.Add(newStr);
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }

    public void CharaChange(string charaName)
    {
        switch (charaName)
        {
            case "kokoro2":
                GameRoot.instance.playerModel.nowCharaPath = "ResObj/player/kokoro2/kokoro2";
                GameRoot.instance.playerModel.nowCharaName = "kokoro2";
                break;
            case "kokoro3":
                GameRoot.instance.playerModel.nowCharaPath = "ResObj/player/kokoro3/kokoro3";
                GameRoot.instance.playerModel.nowCharaName = "kokoro3";

                break;
            default:
                break;
        }
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }
    //public void EqpIntensify(int equipmentIndex)
    //{
    //    GameRoot.instance.playerModel.equipmentList[equipmentIndex].atk += 2;
    //    GameRoot.instance.playerModel.equipmentList[equipmentIndex].level += 1;

    //    EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    //}
    public Equipment EqpIntensify(Equipment equipment)
    {
        Equipment temp = GameRoot.instance.playerModel.equipmentList.Find(x => x.id == equipment.id);
        if (GameRoot.instance.playerModel.Coin < equipment.upgrade_gold)
        {
            TipsSvc.GetInstance().ShowTip("金币不足");
            return temp;
        };
        Equipment temp2;
        if (equipment.level == 5)
        {
            TipsSvc.GetInstance().ShowTip("等级最大");
            return null;
        }

        temp2 = GameConfig.GetInstance().GameConfig_equipmentList.Find(x => x.id.ToString() == (temp.id + 1).ToString());
        GameRoot.instance.playerModel.equipmentList.Remove(temp);
        GameRoot.instance.playerModel.equipmentList.Add(temp2);

        GetCoin(-(temp.upgrade_gold));
        //PlayerModelController.GetInstance().GetCoin(-(_equipment.upgrade_gold));
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        return temp2;

    }
    public Equipment EqpIntensify(Equipment equipment, out bool tempBool)
    {
        Equipment temp = GameRoot.instance.playerModel.equipmentList.Find(x => x.id == equipment.id);
        if (GameRoot.instance.playerModel.Coin < temp.upgrade_gold)
        {
            TipsSvc.GetInstance().ShowTip("金币不足"+ temp.upgrade_gold);
            CoinChangeSvc.GetInstance().Show(0);
            tempBool = false;
            return temp;
        };
        Equipment temp2;
        if (equipment.level == 5)
        {
            TipsSvc.GetInstance().ShowTip("等级最大");
            tempBool = false;
            return null;
        }

        temp2 = GameConfig.GetInstance().GameConfig_equipmentList.Find(x => x.id.ToString() == (temp.id + 1).ToString());
        GameRoot.instance.playerModel.equipmentList.Remove(temp);
        GameRoot.instance.playerModel.equipmentList.Add(temp2);
        //temp = temp2;

        GetCoin(-(temp.upgrade_gold));
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        tempBool = true;
        return temp2;

    }

    public void SetLevelStarDic(string levelName,int star)
    {
        GameRoot.instance.playerModel.LevelStartDic[levelName] = star;
        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }
    public int GetLevelStarDic(string levelName)
    {
        var tempDic = GameRoot.instance.playerModel.LevelStartDic;
        if (tempDic.ContainsKey(levelName))
        {
            return tempDic[levelName];
        }
        return 0;
    }

    public void SetLogList(Log log)
    {
        try
        {

            if (!GameRoot.instance.playerModel.LogDic.ContainsKey(log.ID)) GameRoot.instance.playerModel.LogDic[log.ID] = new List<Log>();
            if (GameRoot.instance.playerModel.LogDic == null) GameRoot.instance.playerModel.LogDic = new Dictionary<int, List<Log>>();
            if (GameRoot.instance.playerModel.LogDic[log.ID] == null) GameRoot.instance.playerModel.LogDic[log.ID] = new List<Log>();
            GameRoot.instance.playerModel.LogDic[log.ID].Add(log);
            EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        }
        catch
        {
            Debug.Log("aaaa");
        }

    }


    public List<Log> GetLogList(int ID)
    {
        try
        {

            return GameRoot.instance.playerModel.LogDic[ID];
        }
        catch
        {
            Debug.Log("getlogFail");
        }
        return null;
    }








    int eqpVoidAtkValue(Equipment equipment)
    {
        if (equipment == null) return 0;
        return equipment.atk<=0?0:equipment.atk;
    }
    int  eqpVoidDefValue(Equipment equipment)
    {
        if (equipment == null) return 0;
        return equipment.def <= 0 ? 0 : equipment.def;
    }
    int  eqpVoidHPValue(Equipment equipment)
    {
        if (equipment == null) return 0;
        return equipment.hp <= 0 ? 0 : equipment.hp;
    }

    public PlayerInfo GetPlayerInfo()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        var playerModel = GameRoot.instance.playerModel;

        //playerInfo.atk = playerModel.atk+eqpVoidAtkValue(playerModel.eqp_weapon)+ eqpVoidAtkValue(playerModel.eqp_other);
        //playerInfo.def = playerModel.def + eqpVoidDefValue(playerModel.eqp_body) + eqpVoidDefValue(playerModel.eqp_leg) + eqpVoidDefValue(playerModel.eqp_other);
        //playerInfo.hp = playerModel.hp;

        playerInfo.atk = playerModel.CharaInfoDic[playerModel.nowCharaName].atk + eqpVoidAtkValue(playerModel.eqp_weapon) + eqpVoidAtkValue(playerModel.eqp_other);
        playerInfo.def = playerModel.CharaInfoDic[playerModel.nowCharaName].def+ eqpVoidDefValue(playerModel.eqp_defense)+ eqpVoidDefValue(playerModel.eqp_other);
        playerInfo.hp = playerModel.CharaInfoDic[playerModel.nowCharaName].hp+ eqpVoidHPValue(playerModel.eqp_decorate)+ eqpVoidHPValue(playerModel.eqp_other);
        //playerInfo.def = playerModel.CharaInfoDic[playerModel.nowCharaName].def;
        //playerInfo.hp = playerModel.CharaInfoDic[playerModel.nowCharaName].hp;

        playerInfo.objPath = playerModel.nowCharaPath;
        return playerInfo;
    }

    string temp = GameConfig.dataStr;
    private void InitPlayerModel()
    {
        PlayerModel tempModel = (PlayerModel)PlayerPrefsDataMgr.Instance.LoadData(typeof(PlayerModel), temp);

        if (tempModel.notNull)
        {

        }
        else
        {
            tempModel = GameConfig.GetInstance().GetDefaultModel();
        }


        GameRoot.instance.playerModel = tempModel;

        SavePlayerModel();
        //invoke
    }

    public void SavePlayerModel()
    {
            PlayerPrefsDataMgr.Instance.SaveData(GameRoot.instance.playerModel, temp);
    }




}