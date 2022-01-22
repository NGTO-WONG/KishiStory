using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    AttackCount,
    PlayerHpLeft,
    MaxBallSize,
}


public class Quest
{
    public QuestType questType;
    public int targetNumber;
    public bool isDone = false;
    public string describe;
    public int attackCounter;
    public int maxBallSize;
    public Quest GetQuest(QuestType type,int targetNumber, string _describe=" ", bool isDone=false)
    {
        Quest tempQuest = new Quest();
        tempQuest.questType = type;
        tempQuest.targetNumber = targetNumber;
        tempQuest.isDone = isDone;
        switch (type)
        {
            case QuestType.AttackCount:
                tempQuest.describe = "������������" + targetNumber.ToString();
                break;
            case QuestType.PlayerHpLeft:
                tempQuest.describe = "Ѫ��������" + targetNumber.ToString();
                break;
            case QuestType.MaxBallSize:
                tempQuest.describe = "������" + targetNumber.ToString();
                break;
            default:
                break;

        }
        return tempQuest;
    }
}
