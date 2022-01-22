using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game3BallFXSvc : BaseManager<Game3BallFXSvc>
{

    public void MixBallFX(string FXPath,Vector3 point,UnityAction FXOverCallBack)
    {

        ResMgr.GetInstance().LoadAsync<GameObject>(FXPath, (obj) => 
        {
            obj.transform.position = point;
            obj.GetComponent<BallFX>().Init(FXOverCallBack);
        });
    }


    public void AttackBallFXWithAttackTrigger(string FXPath, Vector3 point, UnityAction FXOverCallBack)
    {


        ResMgr.GetInstance().LoadAsync<GameObject>(FXPath, (obj) =>
        {
            obj.transform.position = point;
            obj.GetComponent<SwordAttackFx>().Init(FXOverCallBack);
        });
    }
}
