using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowSetting);
    }

    private void ShowSetting()
    {
        Debug.Log("ccc");
        UIManager.GetInstance().ShowPanel<Panel_Setting>("Panel_Setting", E_UI_Layer.Top);
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
