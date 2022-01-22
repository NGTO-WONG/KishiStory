using System.Collections.Generic;

public class LevelAward
{
    public string levelName;
    public List<Equipment> awardEqpList;
    public int awardLevelNum;
    public int awardCoin;
    public List<Props> awardProps;
    public LevelAward(string levelName, List<Equipment> awardEqpList, int awardLevelNum, int awardCoin, List<Props> awardProps)
    {
        this.levelName = levelName;
        this.awardEqpList = awardEqpList;
        this.awardLevelNum = awardLevelNum;
        this.awardCoin = awardCoin;
        this.awardCoin = awardCoin;
        this.awardProps = awardProps;
    }
}