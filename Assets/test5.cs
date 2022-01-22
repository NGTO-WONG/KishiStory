using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInfo
{
    public int index = 1;
}



public class test5 : MonoBehaviour
{
    TestInfo testInfo;
    // Start is called before the first frame update
    void Start()
    {
        testInfo = PlayerPrefsDataMgr.Instance.LoadData(typeof(TestInfo), "testInfo") as TestInfo;
        

        GetComponent<Text>().text = testInfo.index.ToString();
        EventCenter.GetInstance().AddEventListener("test", TextAdd);
    }

    private void TextAdd()
    {
        testInfo.index += 1;

        GetComponent<Text>().text = testInfo.index.ToString();
        PlayerPrefsDataMgr.Instance.SaveData(testInfo,"testInfo");
        Debug.Log(testInfo.index);
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
