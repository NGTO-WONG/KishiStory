using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameRoot : MonoBehaviour
{
    public static GameRoot instance;
    public PlayerModel playerModel;
    private void Awake()
    {
        instance = this;
    }
    //#
    // Start is called before the first frame update
    void Start()
    {


        DontDestroyOnLoad(this.gameObject);

        InitJsonLoader();
        try
        {
            PlayerModelController.GetInstance().Init();
        }
        catch
        {
            PlayerModelController.GetInstance().Init();
            Invoke("T1", 0.1f);
        }


        //EQPLIST();

        foreach (var item in instance.playerModel.CharaInfoDic)
        {
            Debug.Log(item.Key + item.Value.name + "!!!");
        }


    }

    void T1()
    {
        PlayerModelController.GetInstance().Init();
    }
    private void EQPLIST()
    {
        foreach (var item in GameConfig.GetInstance().GameConfig_equipmentList)
        {
            Debug.Log(": " + item.id + " : " + item.name +"v "+ item.upgrade_gold);
        }

        var temp2 = GameRoot.instance.playerModel.equipmentList.Find(t => t.id == 10003);
        //Debug.Log(temp2.id);
        //throw new NotImplementedException();
    }

    private void Test2()
    {
        foreach (var item in GameConfig.GetInstance().GameConfig_fruitList)
        {
            Debug.Log(item.fruit_name + " :"+item.fruit_level.ToString() + " :" + item.fruit_size);
        }
        //throw new NotImplementedException();
    }

    private void InitJsonLoader()
    {
        //Debug.Log("1");
        JsonLoadSvc.GetInstance().Init();


    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    SoundClick();
        //}
        if (Input.GetKeyDown(KeyCode.T))
        {

            var tempList = PlayerModelController.GetInstance().GetLogList(1);
            Debug.Log("--------------------1-------------------");
            foreach (var item in tempList)
            {

                Debug.Log("ID:1" + item.Info);
            }
            var tempList2 = PlayerModelController.GetInstance().GetLogList(2);

            Debug.Log("--------------------2-------------------");
            foreach (var item in tempList2)
            {
                Debug.Log("ID:2" + item.Info);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LogSvc.GetInstance().WriteToDIsk();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CoinChangeSvc.GetInstance().Show(0);
            Debug.Log(GameRoot.instance.playerModel.Coin);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerModelController.GetInstance().GetCoin(10);
            //CoinChangeSvc.GetInstance().Show(10);
            Debug.Log(GameRoot.instance.playerModel.Coin);
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (var item in instance.playerModel.equipmentList)
            {
                Debug.Log(item.level+" "+item.atk);
            }
        }





    }



}
