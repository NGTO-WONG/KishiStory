using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenu : BasePanel
{
    public static BottomMenu instance = null;
    private new void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        init();
    }

    private void init()
    {
        InitBtns();
        try
        {
            EventCenter.GetInstance().AddEventListener(EventDic.HideBottomMenu, () => 
            {
                try
                {

                    Destroy(this.gameObject);
                }
                catch
                {

                }
            });

        }
        catch
        {

        }
        //throw new NotImplementedException();
    }

    private void InitBtns()
    {


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Toggle>().onValueChanged.AddListener((tempBool) =>
            {
                if (tempBool == true)
                {
                    switch (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name)
                    {
                        case "Image_illustrated":
                            SceneLoadSvc.GetInstance().LoadSceneWithFX("illustratedScene", null);
                            //TODO
                            break;
                        case "Image_Chara":
                            SceneLoadSvc.GetInstance().LoadSceneWithFX("ReallyChara", null);
                            //TODO
                            break;
                        case "Image_Adventy":
                            //TODO
                            SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu", null);
                            break;
                        case "Image_Eqp":
                            SceneLoadSvc.GetInstance().LoadSceneWithFX("CharaSetting", () =>
                            {
                                CharaSettingSys.instance.Init();


                                //Debug.Log(CharaSettingSys.instance.equipmentList.Count);
                            });
                            break;

                        default:

                            break;
                    }
                }
            });
        }
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
