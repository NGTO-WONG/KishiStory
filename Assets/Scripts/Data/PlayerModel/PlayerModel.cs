
using System.Collections.Generic;

public class PlayerModel
{
    public bool notNull;
    public List<string> UnlockLevelList = new List<string>();
    public Dictionary<string, int> LevelStartDic = new Dictionary<string, int>();
    public List<Equipment> equipmentList = new List<Equipment>();
    public Dictionary<string, CharaModel> CharaInfoDic = new Dictionary<string, CharaModel>();
    public int Coin;
    public string nowCharaPath;
    public string nowCharaName;
    public Equipment eqp_defense;
    public Equipment eqp_decorate;
    public Equipment eqp_weapon;
    public Equipment eqp_other;



    public Dictionary<int, List<Log>> LogDic;
    //public Dictionary<string, PlayerInfo> CharaDic = new Dictionary<string, PlayerInfo>();
    //public PlayerInfo selectingChara;



}
