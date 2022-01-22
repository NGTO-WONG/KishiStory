using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlAreaMgr : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IPointerClickHandler
{


    public void OnPointerClick(PointerEventData eventData)
    {
        //EventCenter.GetInstance().EventTrigger(EventDic.CreatBall);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        EventCenter.GetInstance().EventTrigger(EventDic.CreatBall);
        //throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("click begin");

        startDragX = eventData.position.x;
        
        //throw new NotImplementedException();
    }
    float startDragX;
    public void OnDrag(PointerEventData eventData)
    {
        float offsetX = Camera.main.ScreenToWorldPoint(eventData.position).x;
        if (offsetX > 3.3f) offsetX = 3.3f;
        if (offsetX < -3.3f) offsetX = -3.3f;
        EventCenter.GetInstance().EventTrigger<float>("ballMoveX", offsetX);
        //Debug.Log(eventData.position.x);
        //Debug.Log(Camera.main.ScreenToWorldPoint(eventData.position).x);
        //throw new NotImplementedException();
    }

    public static ControlAreaMgr instance = null;
    public Button CreatBallRawImage;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public bool lockControlArea = true;

    GameObject Game3;
    public void UnLockControlArea()
    {   
        lockControlArea = false;
        
    }

    public void LockControlArea()
    {
        lockControlArea = true;

    }


    public void Init()
    {
        Game3Init();

        //CreatGame2();
        //EventCenter.GetInstance().AddEventListener(EventDic.Game2Change, Game2Change);
    }

    private void Game3Init()
    {
        Game3 = BallCreator.instance.gameObject;
        BallCreator.instance.CreatFristBall();
        //CreatBallRawImage.onClick.AddListener(() => { EventCenter.GetInstance().EventTrigger(EventDic.CreatBall); });
        //throw new NotImplementedException();
    }






















































    //int Game2Count = 0;
    //private void Game2Change()
    //{
    //    Destroy(nowGame2Obj);
    //    Game2Count++;
    //    try
    //    {
    //        string areaPath = "ResObj/Game2Areas/Areas" + BattleSys.GetInstance().levelAward.levelName + "_" + Game2Count.ToString();
    //        nowGame2Obj = ResMgr.GetInstance().Load<GameObject>(areaPath);
    //        nowGame2Obj.transform.parent = GameObject.Find("Game2").transform;
    //        nowGame2Obj.transform.localScale = new Vector3(1, 1, 1);

    //    }
    //    catch
    //    {

    //        string areaPath = "ResObj/Game2Areas/Areas" + BattleSys.GetInstance().levelAward.levelName + "_0";
    //        nowGame2Obj = ResMgr.GetInstance().Load<GameObject>(areaPath);
    //        nowGame2Obj.transform.parent = GameObject.Find("Game2").transform;
    //        nowGame2Obj.transform.localScale = new Vector3(1, 1, 1);
    //        Game2Count = 0;
    //    }
    //    nowGame2Obj.transform.position = new Vector3(0, 0, 0);

    //    //throw new NotImplementedException();
    //}
    //public GameObject nowGame2Obj;
    //private void CreatGame2()
    //{

    //    string areaPath = "ResObj/Game2Areas/Areas" + BattleSys.GetInstance().levelAward.levelName+"_"+Game2Count.ToString();
    //    nowGame2Obj = ResMgr.GetInstance().Load<GameObject>(areaPath);
    //    nowGame2Obj.transform.parent = GameObject.Find("Game2").transform;
    //    nowGame2Obj.transform.position = new Vector3(0, 0, 0);
    //    nowGame2Obj.transform.localScale = new Vector3(1, 1, 1);
    //    //throw new NotImplementedException();
    //}
}
