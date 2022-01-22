using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
//using ThirdParty.Json.LitJson;
//using ThirdParty.Json.LitJson;
using LitJson;
using System;

public class JsonLoadSvc : BaseManager<JsonLoadSvc>
{
    public void Init()
    {
        SetGameConfigFruitList();
        SetGameConfigStageList();
        SetGameConfigPropsList();
        SetGameConfigEnemyList();
        SetGameConfigEqpList();
        //SetGameConfigHeroList();
        SetPanel_LevelNoteInfoDIc();
    }

    private void SetPanel_LevelNoteInfoDIc()//可能用json改
    {
        Panel_LevelNoteInfo info0 = new Panel_LevelNoteInfo();
        info0.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/forest");
        info0.Text_SceneIntroduce = "森林";
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("1-1", info0);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("1-2", info0);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("1-3", info0);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("1-4", info0);

        Panel_LevelNoteInfo info1 = new Panel_LevelNoteInfo();
        info1.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/beach");
        info1.Text_SceneIntroduce = "沙滩";
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("2-1", info1);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("2-2", info1);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("2-3", info1);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("2-4", info1);
        Panel_LevelNoteInfo info2= new Panel_LevelNoteInfo();
        info2.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/snow");
        info2.Text_SceneIntroduce = "测试文字2";
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("3-1", info2);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("3-2", info2);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("3-3", info2);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("3-4", info2);
        Panel_LevelNoteInfo info3= new Panel_LevelNoteInfo();
        info3.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/desert");
        info3.Text_SceneIntroduce = "测试文字3";
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("4-1", info3);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("4-2", info3);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("4-3", info3);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("4-4", info3);
        Panel_LevelNoteInfo info4= new Panel_LevelNoteInfo();
        info4.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/cavern");
        info4.Text_SceneIntroduce = "测试文字4";
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("5-1", info4);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("5-2", info4);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("5-3", info4);
        GameConfig.GetInstance().Panel_LevelNoteInfoDIc.Add("5-4", info4);
    }

    public JsonData GetJsonData(string name)//这个方法给按钮注册
    {
        //string path = Application.dataPath + "/Resources/Table/" + name + ".json";

        //string jsonString = File.ReadAllText(path);
        string jsonString = ResMgr.GetInstance().Load<TextAsset>("Table/" + name).text;
        //Debug.Log(jsonString);
        JsonData jd = JsonMapper.ToObject(jsonString);
        return jd;
    }

    #region fruit


    public void SetGameConfigFruitList()
    {
        JsonData jd = GetJsonData("fruit");
        //List<j>
        foreach (JsonData item in jd)
        {
            Fruit2 fruit = new Fruit2();
            fruit.fruit_number = Convert.ToInt32(item["fruit_number"].ToString());
            fruit.fruit_level = Convert.ToInt32(item["fruit_level"].ToString());
            fruit.fruit_size = Convert.ToInt32(item["fruit_size"].ToString());
            fruit.fruit_type = Convert.ToInt32(item["fruit_type"].ToString());
            fruit.fruit_element = Convert.ToInt32(item["fruit_element"].ToString());
            fruit.weighted = Convert.ToSingle(item["weighted"].ToString());
            fruit.probability = Convert.ToSingle(item["probability"].ToString());
            fruit.fruit_name = item["fruit_name"].ToString();
            GameConfig.GetInstance().GameConfig_fruitList.Add(fruit);

        }
    }


    #endregion


    #region stage

    public void SetGameConfigStageList()
    {
        JsonData jd = GetJsonData("stage");
       //List<j>
        foreach (JsonData item in jd)
        {
            try
            {

                Stage stage = new Stage();
                stage.stage_number = item["stage_number"].ToString();
                stage.stage_enemy = Array.ConvertAll<string, int>(item["stage_enemy"].ToString().Split(','), int.Parse);
                try
                {
                    stage.drop_equipment = Array.ConvertAll<string, int>(item["drop_equipment"].ToString().Split(','), int.Parse);
                }
                catch
                {
                    stage.drop_equipment = new int[0];
                    Debug.Log("kong");
                }
                stage.drop_props = Array.ConvertAll<string, int>(item["drop_props"].ToString().Split(','), int.Parse);
                stage.drop_experience = Convert.ToInt32(item["drop_experience"].ToString());
                stage.drop_gold = Convert.ToInt32(item["drop_gold"].ToString());
                GameConfig.GetInstance().GameConfig_stageList.Add(stage);
            }
            catch
            {
                Debug.Log("jsonError");
            }

        }
    }
    #endregion


    #region props

    public void SetGameConfigPropsList()
    {
        JsonData jd = GetJsonData("props");

        foreach (JsonData item in jd)
        {
            Props props = new Props();
            props.id = Convert.ToInt32(item["prop_id"].ToString());
            props.name = item["prop_name"].ToString();
            props.type = Convert.ToInt32(item["prop_tyle"].ToString());
            props.useable = Convert.ToInt32(item["use_type"].ToString());
            props.rarity = Convert.ToInt32(item["rarity"].ToString());

            props.describe = item["prop_describe"].ToString();


            GameConfig.GetInstance().GameConfig_propsList.Add(props);
                
        }
    }

    #endregion


    #region enemy

    public void SetGameConfigEnemyList()
    {
        JsonData jd = GetJsonData("enemy");
        foreach (JsonData item in jd)
        {
            EnemyInfo enemy = new EnemyInfo();
            enemy.id = Convert.ToInt32(item["enemy_number"].ToString());
            enemy.hp = Convert.ToInt32(item["enemy_HP"].ToString());
            enemy.atk = Convert.ToInt32(item["enemy_attack"].ToString());
            enemy.def = Convert.ToInt32(item["enemy_defense"].ToString());
            enemy.level = Convert.ToInt32(item["enemy_level"].ToString());

            enemy.weakBallType = GetWeakBallType(Convert.ToInt32(item["weakness_element"].ToString()));
            enemy.element_weighting = Convert.ToSingle(item["enemy_level"].ToString());

            enemy.attackCounter= Convert.ToInt32(item["interval"].ToString());

            enemy.enterWord = item["enterWord"].ToString();
            enemy.objPath = setEnemyObjPath(enemy.id);
            GameConfig.GetInstance().GameConfig_enemyList.Add(enemy);
        }

    }



    BallType GetWeakBallType(int weakID)
    {
        switch (weakID)
        {
            case 1:
                return BallType.fire;
            case 2:
                return BallType.water;
            default:
                return BallType.fire;
        }
    }
    string setEnemyObjPath(int id)
    {
        char monsterObjChar = id.ToString()[0];

        //return "ResObj/enemy/qiling/qiling";
        switch (monsterObjChar)
        {
            case '1':
                return "ResObj/enemy/lion/lion";
            case '2':
                return "ResObj/enemy/fox/fox";
            case '3':

                return "ResObj/enemy/hino/hino";
            case '4':

                return "ResObj/enemy/pig/pig";
            case '5':
                return "ResObj/enemy/hino/hino";
            default:

                return "ResObj/enemy/qiling/qiling";
                break;
        }





        //switch (id)
        //{
        //    case 1001:
        //        return "ResObj/enemy/darkSnack/darkSnack";
        //    case 1002:

        //        return "ResObj/enemy/eagle/eagle";
        //    case 1003:

        //        return "ResObj/enemy/fish/fish";
        //    case 1004:

        //        return "ResObj/enemy/fox/fox";
        //    case 1005:

        //        return "ResObj/enemy/hino/hino";
        //    case 2001:

        //        return "ResObj/enemy/kirin/kirin";
        //    case 2002:

        //        return "ResObj/enemy/lion/lion";
        //    case 2003:

        //        return "ResObj/enemy/lizademan/lizademan";
        //    case 2004:

        //        return "ResObj/enemy/mole/mole";
        //    case 2005:

        //        return "ResObj/enemy/pig/pig";
        //    default:

        //        return "ResObj/enemy/qiling/qiling";
        //        break;
        //}
    }




    #endregion

    #region eqp
    public void SetGameConfigEqpList()
    {
        JsonData jd = GetJsonData("equipment");
        foreach (JsonData item in jd)
        {
            Equipment equipment = new Equipment();
            equipment.id = Convert.ToInt32(item["equipment_number"].ToString());
            equipment.name = item["equipment_name"].ToString();
            equipment.imagePath = setImagePath(equipment.id);
            equipment.type = setType(Convert.ToInt32(item["equipment_type"].ToString()));
            equipment.rarity = setRarity(Convert.ToInt32(item["rarity"].ToString()));
            equipment.level = Convert.ToInt32(item["equipment_level"].ToString());
            equipment.atk = Convert.ToInt32(item["attack_bonus"].ToString());
            equipment.def = Convert.ToInt32(item["defense_bonus"].ToString());
            equipment.hp = Convert.ToInt32(item["health_bonus"].ToString());
            equipment.upgrade_gold = Convert.ToInt32(item["upgrade_gold"].ToString());
            equipment.description = item["equipment_description"].ToString();
            GameConfig.GetInstance().GameConfig_equipmentList.Add(equipment);
        }

    }

    string setType(int type)
    {
        switch (type)
        {
            case 1:
                return "weapon";
            case 2:
                return "defense";
            case 3:
                return "decorate";
            case 4:
                return "other";
            default:
                return "other";
        }

    }

    string setRarity(int rarity)
    {
        switch (rarity)
        {
            case 1:
                return "c";
            case 2:
                return "b";
            case 3:
                return "a";
            case 4:
                return "s";
            case 5:
                return "s";
            default:
                return "s";
        }
    }

    string setImagePath(int id)
    {
        string tempStr = id.ToString();
        //switch (id)
        //{
        //    case 10001:
        //        return "ResImage/Equipment/CW1";
        //    case 10002:
        //        return "ResImage/Equipment/BW1";
        //    case 10003:
        //        return "ResImage/Equipment/AW1";
        //    case 10004:
        //        return "ResImage/Equipment/SW1";
        //    default:

        //        return "ResImage/Equipment/SW2";
        //        break;
        //}


        switch (tempStr[0])
        {
            case '1':
                return "ResImage/Equipment/CW1";
            case '2':
                return "ResImage/Equipment/CB1";
            case '3':
                return "ResImage/Equipment/CO1";
            case '4':
                return "ResImage/Equipment/BO2";
        }

        return null;
    }

    #endregion eqp


    #region hero


    //public void SetGameConfigHeroList()
    //{
    //    JsonData jd = GetJsonData("hero");
    //    List<j>
    //    foreach (JsonData item in jd)
    //    {
    //        PlayerInfo playerInfo = new PlayerInfo();
    //        playerInfo.atk = Convert.ToInt32(item["hero_attack"].ToString());
    //        playerInfo.level = Convert.ToInt32(item["hero_level"].ToString());
    //        playerInfo.hp = Convert.ToInt32(item["hero_HP"].ToString());
    //        playerInfo.def = Convert.ToInt32(item["hero_defense"].ToString());
    //        playerInfo.exp = Convert.ToInt32(item["upgrade_experience"].ToString());

    //        switch (item["hero_number"].ToString()[0])
    //        {
    //            case '1':
    //                playerInfo.objPath = "ResObj/player/kokoro2/kokoro2";
    //                break;
    //            case '2':
    //                playerInfo.objPath = "ResObj/player/kokoro3/kokoro3";
    //                break;
    //        }
    //        GameConfig.GetInstance().playerInfoList.Add(playerInfo);

    //    }
    //}
    #endregion
}
