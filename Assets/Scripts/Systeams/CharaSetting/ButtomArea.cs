using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomArea : MonoBehaviour
{
    RectTransform grid;
    public static ButtomArea instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate, Init);
        //Init();
    }
    public  void Init()
    {
        try
        {

            grid = GameObject.Find("EqpGrid").GetComponent<RectTransform>();
            var tempInt = grid.childCount <= 4 ? 0 : grid.childCount - 4;
            //����grid�߶�
            grid.offsetMin = new Vector2(instance.GetComponent<RectTransform>().offsetMin.x, -222f * tempInt);
            for (int i = 0; i < CharaSettingSys.instance.equipmentList.Count; i++)
            {
                grid.transform.GetChild(i).gameObject.GetComponent<GridItem>().Init(CharaSettingSys.instance.equipmentList[i]);
            }
        }
        catch
        {

        }



        //����ÿ��grid��Ϣ
            

        //if(grid.childCount<=4
        //throw new NotImplementedException();
    }
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener(EventDic.PlayerModelUpdate, Init);

        instance = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
