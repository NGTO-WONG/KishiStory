using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_BattleSceneNextBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener<string>(EventDic.SetNextBallImage, SetNextBallImage);
    }

    private void SetNextBallImage(string arg0)
    {
        var Images = transform.GetChild(0);

        for (int i = 0; i < Images.childCount; i++)
        {
            Images.GetChild(i).gameObject.SetActive(false);
        }


        try
        {
            Images.Find(arg0).gameObject.SetActive(true);
        }
        catch
        {
            Debug.Log(arg0);
        }
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
