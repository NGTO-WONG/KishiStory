using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSettingSys : MonoBehaviour
{
    public static CharaSettingSys instance;
    public GameObject GridItem;
    public GameObject EqpGrid;
    //public ButtomArea buttomArea;
    //public UPArea upArea;
    public List<Equipment> equipmentList;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate, SetEqpList);
        try
        {
            GameObject.Find("Image_Adventy").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_illustrated").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_Eqp").GetComponent<Animator>().Play("Selected");
            GameObject.Find("Image_Chara").GetComponent<Animator>().Play("Normal");
        }
        catch
        {
            Debug.Log("bottomBtnsError");
        }

    }

    private void SetEqpList()
    {
        equipmentList = GameRoot.instance.playerModel.equipmentList;
    }

    public void Init()
    {
        equipmentList = GameRoot.instance.playerModel.equipmentList;

        //Debug.Log(equipmentList.Count);
        for (int i = 0; i < equipmentList.Count; i++)
        {
            Instantiate(GridItem, EqpGrid.transform);
        }
        ButtomArea.instance.Init();
        UPArea.instance.Init();


        SetBGM();

    }

    private void SetBGM()
    {

        MusicMgr.GetInstance().PlayBkMusic("charaSetting");

        MusicMgr.GetInstance().ChangeBKValue(1f);
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        
    }



}
