using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridChara : MonoBehaviour
{

    public string CharaName;
    // Start is called before the first frame update
    void Start()
    {
        CharaName = gameObject.name.Split('_')[1];
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        PlayerModelController.GetInstance().CharaChange(CharaName);
        //throw new NotImplementedException();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
