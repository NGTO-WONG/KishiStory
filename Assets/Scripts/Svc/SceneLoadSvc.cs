using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoadSvc : BaseManager<SceneLoadSvc>
{
    //public void LoadSceneWithFX(string sceneName, Action sceneLoadOverCallback=null)
    //{
    //    GameObject LoadingObj;
    //    UIManager.GetInstance().ShowPanel<Loading3>("Loading3", E_UI_Layer.System, (obj) =>
    //    {
    //        LoadingObj = obj.gameObject;
    //        //obj.GetComponent<Animator>().Play("Show");
    //        LoadingObj.GetComponent<Loading3>().Init(sceneName,()=> 
    //        {

    //            ScenesMgr.GetInstance().LoadSceneAsyn(sceneName, () =>
    //            {

    //                obj.Hide();

    //                try
    //                {

    //                    sceneLoadOverCallback.Invoke();
    //                }
    //                catch
    //                {

    //                }
    //            });
    //        });
    //    });
    //}
    public void LoadSceneWithFX(string sceneName, Action sceneLoadOverCallback=null)
    {
        sceneLoadOverCallback += () =>{ };
        UIManager.GetInstance().ShowPanel<Loading3>("Loading3", E_UI_Layer.System, (loading3) =>
        {
            //obj.GetComponent<Animator>().Play("Show");
            loading3.Init(sceneName,()=> 
            {

                ScenesMgr.GetInstance().LoadSceneAsyn(sceneName, () =>
                {

                    sceneLoadOverCallback.Invoke();
                    sceneLoadOverCallback = () => { };
                    loading3.Hide();

                });
            },()=>
            {

                try
                {
                    sceneLoadOverCallback.Invoke();
                    //sceneLoadOverCallback.Invoke();
                }
                catch
                {
                    Debug.Log("aaa");
                }
            });
        });
    }
}
