using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IllustratedBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        GetComponent<Button>().onClick.AddListener(BtnClick);
        //throw new NotImplementedException();
    }

    private void BtnClick()
    {
        Debug.Log(gameObject.name);
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
