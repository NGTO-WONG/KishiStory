using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test4 : MonoBehaviour
{
    //public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        EventCenter.GetInstance().EventTrigger("test");
    }
}
