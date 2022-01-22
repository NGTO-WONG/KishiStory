using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordAttackFx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    UnityAction callback;
    public void Init(UnityAction FXoverCallBack)
    {
        callback = FXoverCallBack;
        MoveToPlayer();
    }
    public void OverCallBack()
    {
        try
        {

            callback();
        }
        catch
        {
            Debug.Log("FX");
        }
        Destroy(gameObject);
    }



    void MoveToPlayer()
    {
        try
        {
            Vector3 playerPoint = BattleAreaMgr2.instance.nowPlayerInfo.obj.transform.position;
            var tweener=gameObject.transform.DOMove(playerPoint+new Vector3(0,4,0), 1f, false);
            tweener.onComplete =()=> { callback(); Destroy(this.gameObject); };
        }
        catch
        {
            Debug.Log("MoveToPlayer Error");
        }

    }
}
