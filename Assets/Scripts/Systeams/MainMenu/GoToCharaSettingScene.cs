using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToCharaSettingScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //Debug.Log("a");
            SceneLoadSvc.GetInstance().LoadSceneWithFX("CharaSetting", () =>
            {
                CharaSettingSys.instance.Init();
                

                //Debug.Log(CharaSettingSys.instance.equipmentList.Count);
            });

        });

    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
