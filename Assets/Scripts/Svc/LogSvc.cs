using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log
{
    public int ID;
    public string Info;

}

public class LogSvc : BaseManager<LogSvc>
{
    public void SaveLog1(string ballA,string ballASize,string ballB,string ballBSize,string attackSucees,string damage)
    {
        Log tempLog = new Log();
        tempLog.ID = 1;
        tempLog.Info = System.DateTime.Now + "_" + ballA + "_" + ballASize + "_" + ballB + "_" + ballBSize + "_" + attackSucees + "_" + damage;
        PlayerModelController.GetInstance().SetLogList(tempLog);
    }
    public void SaveLog2(string ballName)
    {

        Log tempLog = new Log();
        tempLog.ID = 2;
        int tempInt = 0;
        if(PlayerModelController.GetInstance().GetLogList(2) !=null&& PlayerModelController.GetInstance().GetLogList(2).Find(x => x.Info.Split('_')[2] == ballName) != null)
        {
            var item = PlayerModelController.GetInstance().GetLogList(2).FindLast(x => x.Info.Split('_')[2] == ballName);
            int oldValue = Convert.ToInt32(item.Info.Split('_')[1]);
            tempInt = oldValue + 1;
            tempLog.Info = System.DateTime.Now + "_" + tempInt.ToString() + "_" + ballName;
            PlayerModelController.GetInstance().SetLogList(tempLog);
        }
        else
        {

            tempLog.Info = System.DateTime.Now + "_" + "1" + "_" + ballName;
            PlayerModelController.GetInstance().SetLogList(tempLog);
            return;
        }
    }
    public void ShowLog(int ID)
    {
        var templist = PlayerModelController.GetInstance().GetLogList(ID);
        foreach (var item in templist)
        {
            Debug.Log(item.Info);
        }
    }



    public void WriteToDIsk()
    {
        List<string> tempList = new List<string>();
        tempList.Add("----------------1------------------");
        foreach (var item in GameRoot.instance.playerModel.LogDic[1])
        {
            tempList.Add(item.Info);

        }
        tempList.Add("----------------2------------------");
        foreach (var item in GameRoot.instance.playerModel.LogDic[2])
        {
            tempList.Add(item.Info);
        }

        System.IO.File.WriteAllLines(@"D:\WriteLines.txt", tempList);
    }
}
