using System.Collections.Generic;
using UnityEngine;
using static Equipment;



public class GameConfig:BaseManager<GameConfig>
{
    public static string dataStr = "PlayerModel3.121";
    public void Init()
    {

    }

    #region 技能系统






    #endregion



    #region 角色升级属性成长
    public static int levelIncrease_hp = 200;
    public static int levelIncrease_atk = 5;
    public static int levelIncrease_def = 5;
    #endregion
    #region 角色数值

    //public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();
    /// <summary>
    /// ////////////玩家
    /// </summary>
    public PlayerInfo kokoro = new PlayerInfo
    {
        hp = 1000,
        atk = 100,
        def = 10,
        objPath = "ResObj/player/kokoro/kokoro",
    };
    public static List<int> exp2LevelList = new List<int>()
    {
        100,230,390,800,1050,1330,1640,1980,2350,2750
    };

    public PlayerInfo kokoro2 = new PlayerInfo
    {
        level = 1,
        hp = 1000,
        atk =200,
        def = 10,
        exp = 0,
        objPath = "ResObj/player/kokoro2/kokoro2",
    };

    public PlayerInfo kokoro3 = new PlayerInfo
    {
        level = 1,
        hp = 1000,
        atk = 10101,
        def = 1011,
        exp = 0,
        objPath = "ResObj/player/kokoro3/kokoro3",
    };







    /// <summary>
    /// ///////////////敌人
    /// </summary>
    public EnemyInfo darkSnack = new EnemyInfo
    {
        id = 1001,
        hp = 500,
        atk = 10,
        def = 5,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/darkSnack/darkSnack",
    };
    public EnemyInfo eagle = new EnemyInfo
    {

        id = 1002,
        hp = 600,
        atk = 20,
        def = 5,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/eagle/eagle",
    };
    public EnemyInfo fish = new EnemyInfo
    {

        id = 1003,
        hp = 20,
        atk = 5,
        def = 1,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/fish/fish",
    };
    public EnemyInfo fox = new EnemyInfo
    {
        id = 1003,
        hp = 700,
        atk = 30,
        def = 10,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/fox/fox",
    };
    public EnemyInfo hino = new EnemyInfo
    {
        id = 1004,
        hp = 800,
        atk = 40,
        def = 10,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/hino/hino",
    };
    public EnemyInfo kirin = new EnemyInfo
    {
        id = 1005,
        hp = 900,
        atk = 50,
        def = 15,

        attackCounter = 5,
        weakBallType = BallType.water,

        objPath = "ResObj/enemy/kirin/kirin",
    };
    public EnemyInfo lion = new EnemyInfo
    {
        id = 2001,
        hp = 700,
        atk = 20,
        def = 10,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/lion/lion",
    };
    public EnemyInfo lizademan = new EnemyInfo
    {
        id = 2002,
        hp = 800,
        atk = 30,
        def = 10,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/lizademan/lizademan",
    };
    public EnemyInfo mole = new EnemyInfo
    {
        id = 2003,
        hp = 900,
        atk = 40,
        def = 15,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/mole/mole",
    };
    public EnemyInfo pig = new EnemyInfo
    {
        id = 2004,
        hp = 1000,
        atk = 50,
        def = 15,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/pig/pig",
    };
    public EnemyInfo qiling = new EnemyInfo
    {
        id = 2005,
        hp = 1100,
        atk = 60,
        def = 20,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/qiling/qiling",
    };
    public EnemyInfo warrior = new EnemyInfo
    {
        id = 2006,
        hp = 1200,
        atk = 70,
        def = 25,

        attackCounter = 5,
        weakBallType = BallType.fire,
        objPath = "ResObj/enemy/warrior/warrior",
    };
    public EnemyInfo warriorwoman = new EnemyInfo
    {
        id = 2007,
        hp = 1300,
        atk = 80,
        def = 30,

        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/warriorwoman/warriorwoman",
    };
    public EnemyInfo wolf = new EnemyInfo
    {
        id = 2008,
        hp = 1400,
        atk = 90,
        def = 35,
        attackCounter = 5,
        weakBallType = BallType.fire,

        objPath = "ResObj/enemy/wolf/wolf",
    };




    #endregion

    #region XML路径

    public static string XML_enemy = "XML/setting/enemy";
    public static string XML_equipment = "XML/setting/equipment";
    public static string XML_fruit = "XML/setting/fruit";
    public static string XML_hero = "XML/setting/hero";
    public static string XML_props = "XML/setting/props";
    public static string XML_stage = "XML/setting/stage";
    #endregion
    #region 玩家存档初始化



    public List<CharaInfo> GameConfig_charaList = new List<CharaInfo>();
    public PlayerModel GetDefaultModel()
    {
        PlayerModel _defaultModel = new PlayerModel();
        _defaultModel.notNull = true;
        _defaultModel.UnlockLevelList.Add("1-1");
        _defaultModel.Coin = 10;
        _defaultModel.nowCharaPath = kokoro2.objPath;
        _defaultModel.nowCharaName = "kokoro2";
        _defaultModel.LevelStartDic.Add("1-1", 0);
        _defaultModel.LogDic = new Dictionary<int, List<Log>>();
        _defaultModel.LogDic.Add(0, new List<Log>());
        _defaultModel.LogDic.Add(1, new List<Log>());
        CharaModel temp1 = new CharaModel();
        temp1.atk = kokoro2.atk;
        temp1.level = kokoro2.level;
        temp1.def = kokoro2.def;
        temp1.hp = kokoro2.hp;
        temp1.objPath = kokoro2.objPath;
        temp1.exp = kokoro2.exp;
        temp1.name = "kokoro2";


        _defaultModel.CharaInfoDic.Add("kokoro2", temp1);

        CharaModel temp2 = new CharaModel();
        temp2.atk = kokoro3.atk;
        temp2.level = kokoro3.level;
        temp2.def = kokoro3.def;
        temp2.hp = kokoro3.hp;
        temp2.objPath = kokoro3.objPath;
        temp2.exp = kokoro3.exp;
        temp2.name = "kokoro3";

        _defaultModel.CharaInfoDic.Add("kokoro3", temp2);
        UnityEngine.Debug.Log("firstIn");

        foreach (var item in _defaultModel.CharaInfoDic)
        {
            Debug.Log(item.Key + item.Value.name + "sb");
        }

        return _defaultModel;
    }

    #endregion

    #region 伤害计算倍率配置
    public List<Fruit2> GameConfig_fruitList = new List<Fruit2>();


    ////剑的大小加成
    public static float swordSize(int level)
    {
        switch (level)
        {
            case 1:
                return 1f;
                //break;
            case 2:
                return 2f;
                //break;
            case 3:
                return 3f;
                //break;
            case 4:
                return 4f;
                //break;
            case 5:
                return 5f;
                //break;
            default:
                return 1;
                //break;
        }
    }

    ///敌人弱点加权
    public static float weakWeight = 1.5f;  //不同1.5倍
    public static float weakWeight2 = 0.5f; //相同属性伤害减半






    #endregion



    #region 特效
    public static string ballMixFX = "FX/BallMixFX";

    public static string fireSwordAttackFx = "FX/fireSwordAttackFx";


    #endregion

    #region 道具

    //public static string coinImagePath = "ResImage/Coin/coin"; //不知道能不能删。。
    public List<Props> GameConfig_propsList= new List<Props>();

    public static Props SetProps(int id, string name, int type, string describe, int rarity, int useable)
    {
        Props props = new Props();

        props.id = id;
        props.name = name;
        props.type = type;
        props.describe = describe;
        props.rarity = rarity;
        props.useable = useable;
        return props;
    }

    Props testProps1 = SetProps(101, "testProps1", 0, "被动道具，在特定系统中使用", 1, 0);
    Props testProps2 = SetProps(102, "testProps2", 1, "被动道具，在特定系统中使用", 1, 1);
    #endregion




    #region 装备数值



    public List<Equipment> GameConfig_equipmentList = new List<Equipment>();


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="imagePath"></param>
    /// <param name="type"></param>
    /// <param name="rarity"></param>
    /// <param name="level"></param>
    /// <param name="atk"></param>
    /// <param name="def"></param>
    /// <param name="hp"></param>
    /// <returns></returns>
    //public static Equipment SetEquipment(int id, string name,string description, string imagePath, string type, string rarity, int level = 1, int atk = 0, int def = 0, int hp = 0)
    //{
    //    Equipment equipment = new Equipment();
    //    equipment.id = id;
    //    equipment.name = name;
    //    equipment.imagePath = imagePath;
    //    equipment.type = type;
    //    equipment.rarity = rarity;
    //    equipment.level = level;
    //    equipment.atk = atk;
    //    equipment.def = def;
    //    equipment.hp = hp;
    //    equipment.description = description;
    //    return equipment;
    //}
    
    //public Equipment SW1 = SetEquipment(10024, "SW1", "测试武器描述", "ResImage/Equipment/SW1", "weapon", "s", 1, 20, 0, 0);
    //public Equipment SW2 = SetEquipment(10025, "SW2", "测试武器描述", "ResImage/Equipment/SW2", "weapon", "s", 1, 20, 0, 0);
    //public Equipment AW1 = SetEquipment(10005, "AW1", "测试武器描述", "ResImage/Equipment/AW1", "weapon", "a", 1, 20, 0, 0);
    //public Equipment AW2 = SetEquipment(10006, "AW2", "测试武器描述", "ResImage/Equipment/AW2", "weapon", "a", 1, 20, 0, 0);
    //public Equipment CW1 = SetEquipment(10017, "CW1", "测试武器描述", "ResImage/Equipment/CW1", "weapon", "c", 1, 20, 0, 0);
    //public Equipment BW1 = SetEquipment(10012, "BW1", "测试武器描述", "ResImage/Equipment/BW1", "weapon", "b", 1, 20, 0, 0);
    //public Equipment BW2 = SetEquipment(10013, "BW2", "测试武器描述", "ResImage/Equipment/BW2", "weapon", "b", 1, 20, 0, 0);


    //public Equipment SB1 = SetEquipment(10018, "SB1", "测试防具描述", "ResImage/Equipment/SB1", "defense", "s", 1, 0, 20, 0);
    //public Equipment SB2 = SetEquipment(10019, "SB2", "测试防具描述", "ResImage/Equipment/SB2", "defense", "s", 1, 0, 20, 0);
    //public Equipment SL1 = SetEquipment(10020, "SL1", "测试防具描述", "ResImage/Equipment/SL1", "defense", "s", 1, 0, 20, 0);
    //public Equipment SL2 = SetEquipment(10021, "SL2", "测试防具描述", "ResImage/Equipment/SL2", "defense", "s", 1, 0, 20, 0);
    //public Equipment AB1 = SetEquipment(10001, "AB1", "测试防具描述", "ResImage/Equipment/AB1", "defense", "a", 1, 0, 20, 0);
    //public Equipment AB2 = SetEquipment(10002, "AB2", "测试防具描述", "ResImage/Equipment/AB2", "defense", "a", 1, 0, 20, 0);
    //public Equipment AL1 = SetEquipment(10003, "AL1", "测试防具描述", "ResImage/Equipment/AL1", "defense", "a", 1, 0, 20, 0);
    //public Equipment BB1 = SetEquipment(10006, "BB1", "测试防具描述", "ResImage/Equipment/BB1", "defense", "b", 1, 0, 20, 0);
    //public Equipment BB2 = SetEquipment(10007, "BB2", "测试防具描述", "ResImage/Equipment/BB2", "defense", "b", 1, 0, 20, 0);
    //public Equipment BL1 = SetEquipment(10008, "BL1", "测试防具描述", "ResImage/Equipment/BL1", "defense", "b", 1, 0, 20, 0);
    //public Equipment BL2 = SetEquipment(10009, "BL2", "测试防具描述", "ResImage/Equipment/BL2", "defense", "b", 1, 0, 20, 0);
    //public Equipment CB1 = SetEquipment(10014, "CB1", "测试防具描述", "ResImage/Equipment/CB1", "defense", "c", 1, 0, 20, 0);
    //public Equipment CL1 = SetEquipment(10015, "CL1", "测试防具描述", "ResImage/Equipment/CL1", "defense", "c", 1, 0, 20, 0);


    //public Equipment CO1 = SetEquipment(10016, "CO1", "测试穿戴描述", "ResImage/Equipment/CO1", "decorate", "c", 1, 0, 0,100);
    //public Equipment BO1 = SetEquipment(10010, "BO1", "测试穿戴描述", "ResImage/Equipment/BO1", "decorate", "b", 1, 0, 0,100);
    //public Equipment BO2 = SetEquipment(10011, "BO2", "测试穿戴描述", "ResImage/Equipment/BO2", "decorate", "b", 1, 0, 0,100);
    //public Equipment AO1 = SetEquipment(10004, "AO1", "测试穿戴描述", "ResImage/Equipment/AO1", "decorate", "a", 1, 0, 0,100);
    //public Equipment SO1 = SetEquipment(10022, "SO1", "测试穿戴描述", "ResImage/Equipment/SO1", "decorate", "s", 1, 0, 0,100);
    //public Equipment SO2 = SetEquipment(10023, "SO2", "测试穿戴描述", "ResImage/Equipment/SO2", "decorate", "s", 1, 0, 0,100);


    //public Equipment other = SetEquipment(40001, "other", "尚未实现的特殊装备", "ResImage/Equipment/SO2", "other", "s", 1, 20, 20,100);



    #endregion

    #region 关卡敌人配置
    public List<EnemyInfo> GameConfig_enemyList = new List<EnemyInfo>();
    public List<Stage> GameConfig_stageList = new List<Stage>();

    //public static List<EnemyInfo> enemyTestInfos1 = new List<EnemyInfo>() { }
    List<EnemyInfo> GetEnemyList(params int[] id)
    {

        var tempList = GameConfig_enemyList;
        var enemyList = new List<EnemyInfo>();
        for (int i = 0; i < id.Length; i++)
        {
            enemyList.Add(tempList.Find(x => x.id == id[i]).GetClone());
        }
        return enemyList;
    }



    public List<EnemyInfo> GetEnemyInfos(string LevelName)
    {

        List<EnemyInfo> tempList=new List<EnemyInfo>();
        var tempIntArray = GameConfig_stageList.Find(x => x.stage_number == LevelName);
        tempList = GetEnemyList(tempIntArray.stage_enemy);

        return tempList;
    }

    #endregion

    #region 关卡回报配置

    List<Equipment> GetEqpuipmentList(params int[] id)
    {

        var tempList = GameConfig_equipmentList;
        var eqpList = new List<Equipment>();
        for (int i = 0; i < id.Length; i++)
        {
            eqpList.Add(tempList.Find(x => x.id == id[i]).GetClone());
        }
        return eqpList;

    }

    List<Props> GetPropsList(params int[] id)
    {
        var tempList = new List<Props>();
        tempList.Add(testProps1);
        tempList.Add(testProps2);

        var propsList = new List<Props>();
        for (int i = 0; i < id.Length; i++)
        {
            propsList.Add(tempList.Find(x => x.id == id[i]).GetClone());
        }
        return propsList;

    }



    public LevelAward GetAwards(string LevelName)
    {

        LevelAward levelAward=null;
        var stage = GameConfig_stageList.Find(x => x.stage_number == LevelName);
        levelAward = new LevelAward(LevelName, GetEqpuipmentList(stage.drop_equipment), stage.drop_experience, stage.drop_gold, GetPropsList(stage.drop_props));

        //switch (LevelName)
        //{
        //    case "1-1":
        //        //                                关卡名    装备              经验,金币,道具
        //        levelAward = new LevelAward("1-1", GetEqpuipmentList(10001), 1, 10,GetPropsList(101));
        //        break;
        //    case "1-2":
        //        levelAward = new LevelAward("1-2", GetEqpuipmentList(10002), 2, 20, GetPropsList(102));
        //        break;
        //    case "1-3":
        //        levelAward = new LevelAward("1-3", GetEqpuipmentList(10003), 3, 30, GetPropsList(101,102));
        //        break;
        //    case "1-4":
        //        levelAward = new LevelAward("1-4", GetEqpuipmentList(20001), 3, 30, GetPropsList(101, 102, 101, 102, 101, 102, 101, 102, 101, 102));
        //        break;
        //    case "1-5":
        //        levelAward = new LevelAward("1-5", GetEqpuipmentList(20002), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-6":
        //        levelAward = new LevelAward("1-6", GetEqpuipmentList(20003), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-7":
        //        levelAward = new LevelAward("1-7", GetEqpuipmentList(30001), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-8":
        //        levelAward = new LevelAward("1-8", GetEqpuipmentList(30002), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-9":
        //        levelAward = new LevelAward("1-9", GetEqpuipmentList(30003), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-10":
        //        levelAward = new LevelAward("1-10", GetEqpuipmentList(10001, 10002, 10003, 20001, 20002, 30001), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-11":
        //        levelAward = new LevelAward("1-11", GetEqpuipmentList(40001), 3, 30, GetPropsList(101));
        //        break;
        //    case "1-12":
        //        levelAward = new LevelAward("1-12", GetEqpuipmentList(10001), 3, 30, GetPropsList(101));
        //        break;
        //}
        return levelAward;
    }

    #endregion

    #region 关卡小任务配置
    public List<Quest> GetQuestCondition(string levelName)
    {
        List<Quest> tempQuest = new List<Quest>();
        Quest quester = new Quest();

        Quest q1 = quester.GetQuest(QuestType.AttackCount, 30);
        Quest q2 = quester.GetQuest(QuestType.PlayerHpLeft, 10);
        Quest q3 = quester.GetQuest(QuestType.MaxBallSize, 3);
        switch (levelName)
        {
            case "1-1":
                q1 = quester.GetQuest(QuestType.AttackCount,20);
                q2 = quester.GetQuest(QuestType.PlayerHpLeft, 10);
                q3 = quester.GetQuest(QuestType.MaxBallSize,9);
                tempQuest.Add(q1);
                tempQuest.Add(q2);
                tempQuest.Add(q3);
                break;
            case "1-2":
                q1 = quester.GetQuest(QuestType.AttackCount,11);
                q2 = quester.GetQuest(QuestType.PlayerHpLeft, 10);
                q3 = quester.GetQuest(QuestType.MaxBallSize,9);
                tempQuest.Add(q1);
                tempQuest.Add(q2);
                tempQuest.Add(q3);
                break;
            default:

                tempQuest.Add(q1);
                tempQuest.Add(q2);
                tempQuest.Add(q3);
                break;
        }
        
        return tempQuest;
    }

    #endregion


    #region 关卡场景配置
    public string GetEnvPath(string levelName)
    {
        string[] nameArray = levelName.Split('-');
        //if (levelName == "1-2") return "ResObj/Environment/cavern";

        switch (nameArray[0])
        {
            case "1":
                return "ResObj/Environment/forest";
            case "2":
                return "ResObj/Environment/beach";
            case "3":
                return "ResObj/Environment/snow";
            case "4":
                return "ResObj/Environment/desert";
            case "5":
                return "ResObj/Environment/cavern";

            default:
                return "ResObj/Environment/cavern";
        }
    }



    #endregion


    #region 大世界按钮配置
    public Panel_LevelNoteInfo GetLevelNoteInfo(string levelName)
    {
        if (Panel_LevelNoteInfoDIc.ContainsKey(levelName))
        {
            return Panel_LevelNoteInfoDIc[levelName];
        }
        else
        {
            Debug.Log("关卡不存在");
            Panel_LevelNoteInfo info0 = new Panel_LevelNoteInfo();
            info0.Image_SceneImage = ResMgr.GetInstance().Load<Sprite>("ResImage/UI/MainMenu/forest");
            info0.Text_SceneIntroduce = "没配置该关卡";
            return info0;

        }
    }
    public Dictionary<string, Panel_LevelNoteInfo> Panel_LevelNoteInfoDIc = new Dictionary<string, Panel_LevelNoteInfo>();
    #endregion

}