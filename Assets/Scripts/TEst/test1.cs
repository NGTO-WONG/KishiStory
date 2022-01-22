using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => 
        {
            //var tempGameCfg = new GameConfig();
            //tempGameCfg.enemyTestInfos.Add(tempGameCfg.darkSnack);
            //var player = tempGameCfg.kokoro;
            //player.hp = 1000;
            //player.objPath = "ResObj/player/kokoro/kokoro";
            ////Debug.Log(tempEnemys.Count);
            //SceneLoadSvc.GetInstance().LoadSceneWithFX("BattleScene",()=> 
            //{
            //    BattleSys.GetInstance().Init(player, tempGameCfg.enemyTestInfos);
            //});
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
