using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItem : BasePanel
{
    Button Button_Eqp;
    Button Button_eqpIntensify;
    int level;
    int atk;
    int def;
    int hp;
    string eqpName;
    string type;
    string imagePath;
    Equipment _equipment;
    public void Init(Equipment equipment)
    {
        _equipment = equipment;
        this.level = equipment.level;
        this.atk = equipment.atk;
        this.def = equipment.def;
        this.hp = equipment.hp;
        this.eqpName = equipment.name;
        this.type = equipment.type;
        this.imagePath = equipment.imagePath;
        Button_Eqp = GetControl<Button>("Button_eqpOn");
        Button_eqpIntensify = GetControl<Button>("Button_eqpIntensify");

        UpdateInfo();

        Button_Eqp.onClick.RemoveAllListeners();
        Button_Eqp.onClick.AddListener(EqpOn);
        Button_eqpIntensify.onClick.RemoveAllListeners();
        Button_eqpIntensify.onClick.AddListener(Intensify);

        //EventCenter.GetInstance().AddEventListener<Equipment>("eqp", Init);
    }

    
    private void Intensify()
    {
        if (_equipment.level < 5)
        {
            bool tempBool = false;
            Init(PlayerModelController.GetInstance().EqpIntensify(_equipment,out tempBool));
            if (tempBool == false)
            {
                return;
            }
            else
            {
                //Debug.Log(this.atk+"11");
                GetControl<Text>("Text_atk").text = this.atk.ToString();
                GetControl<Text>("Text_def").text = this.def.ToString();
                GetControl<Text>("Text_hp").text = this.hp.ToString();
                UpdateInfo();
                //var temp = GameRoot.instance.playerModel.equipmentList.Find(x => x.id == _equipment.id);
                //CoinChangeSvc.GetInstance().Show(-(_equipment.upgrade_gold));
            }

        }
        else
        {
            TipsSvc.GetInstance().ShowTip("等级最大");
        }

        EqpOn();

        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        //Debug.Log(GameRoot.instance.playerModel.eqp_weapon.atk);

        PlayerPrefsDataMgr.Instance.SaveData(GameRoot.instance.playerModel, GameConfig.dataStr);
        //throw new NotImplementedException();
    }

    private void EqpOn()
    {
        switch (_equipment.type)
        {
            case "defense":
                PlayerModelController.GetInstance().Eqp_defense(_equipment);
                break;
            case "other":
                PlayerModelController.GetInstance().Eqp_other(_equipment);
                break;
            case "decorate":
                PlayerModelController.GetInstance().Eqp_decorate(_equipment);
                break;
            case "weapon":
                PlayerModelController.GetInstance().Eqp_weapon(_equipment);
                break;
        }
        try
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("attack");
        }
        catch { }

        EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
        //TipsSvc.GetInstance().ShowTip(_equipment.id + " :" + " " + _equipment.atk + " :");
        //Eqp.enabled = false;
        //throw new NotImplementedException();
    }

    private void UpdateInfo()
    {

        GetControl<Image>("Image_eqpIcon").sprite= ResMgr.GetInstance().Load<Sprite>(imagePath);
        GetControl<Text>("Text_eqpName").text = eqpName+"+"+level;
        GetControl<Text>("Text_atk").text = atk.ToString();
        GetControl<Text>("Text_def").text = def.ToString();
        GetControl<Text>("Text_hp").text = hp.ToString();
        //throw new NotImplementedException();
        //EventCenter.GetInstance().EventTrigger(EventDic.PlayerModelUpdate);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
