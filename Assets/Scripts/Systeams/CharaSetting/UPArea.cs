using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPArea : MonoBehaviour
{

    public Image weapon;
    public Image other;
    public Image decorate;
    public Image defense;
    public GameObject charaRawImage;
    public GameObject charaRawImageObj;
    public static UPArea instance; 
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate,UpdateNowEqp);
        EventCenter.GetInstance().AddEventListener(EventDic.PlayerModelUpdate,CharaChangeUpdate);
    }
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener(EventDic.PlayerModelUpdate,UpdateNowEqp);
        EventCenter.GetInstance().RemoveEventListener(EventDic.PlayerModelUpdate, CharaChangeUpdate);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }
    public void Init()
    {
        //TODO°´Å¥¹¦ÄÜ

        //Debug.Log("aaaaaaa");
        //
        CharaChangeUpdate();
        UpdateNowEqp();
        InitPlayerModel();
        SetEqpBroder();
    }
    public Sprite EqpBroder;
    private void SetEqpBroder()
    {

        //throw new NotImplementedException();
    }

    public Text Text_Level;
    public Text Text_ATK;
    public Text Text_DEF;
    public Text Text_HP;
    private void InitPlayerModel()
    {

        string nowCharaName = GameRoot.instance.playerModel.nowCharaName;
        var model = GameRoot.instance.playerModel.CharaInfoDic[nowCharaName];
        Text_Level.text = model.level.ToString();
        Text_ATK.text = PlayerModelController.GetInstance().GetPlayerInfo().atk.ToString();
        Text_DEF.text = PlayerModelController.GetInstance().GetPlayerInfo().def.ToString();
        Text_HP.text = PlayerModelController.GetInstance().GetPlayerInfo().hp.ToString();
        //throw new NotImplementedException();
    }

    private void CharaChangeUpdate()
    {
        Destroy(charaRawImageObj);
        charaRawImageObj = ResMgr.GetInstance().Load<GameObject>(GameRoot.instance.playerModel.nowCharaPath);
        charaRawImageObj.transform.parent = instance.charaRawImage.transform;
        charaRawImageObj.transform.localPosition = new Vector3(0, 0, 888);
        charaRawImageObj.transform.localScale = new Vector3(111, 111, 1);
        charaRawImageObj.layer = 7;
    }

    private void UpdateNowEqp()
    {
        //Debug.Log(GameRoot.instance.playerModel.eqp_weapon.imagePath);
        try
        {
            if (ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_weapon.imagePath) != null)
            {
                weapon.sprite = ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_weapon.imagePath);
            }
            else
            {

            }
        } catch{}
        try
        {
            if (ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_other.imagePath) != null)
            {
                
            other.sprite = ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_other.imagePath);
            }
        }
        catch {}
        try
        {
            if (ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_decorate.imagePath)!=null)
            {

                decorate.sprite = ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_decorate.imagePath);
            }
        }
        catch{}
        try
        {
            if (ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_defense.imagePath) != null)
            {
                defense.sprite = ResMgr.GetInstance().Load<Sprite>(GameRoot.instance.playerModel.eqp_defense.imagePath);
            }
        }
        catch
        {
            Debug.Log("¿Õ");
        }
        //throw new NotImplementedException();

        InitPlayerModel();


    }
}
