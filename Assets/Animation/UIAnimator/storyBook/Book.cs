using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    BookPro bookPro;
    
    AutoFlip autoFlip;
    public Image BlackScreen;
    // Start is called before the first frame update
    void Start()
    {
        bookPro = GetComponent<BookPro>();
        autoFlip = GetComponent<AutoFlip>();
        EventCenter.GetInstance().AddEventListener("BookChange", BookChange);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void BookChange()
    {
        InvokeRepeating("test", 0.1f, 0.15f);
        InvokeRepeating("test3", 0.1f, 0.05f);
        Invoke("t2",1.5f);
    }

    private void t2()
    {

            SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu", null);
        //throw new NotImplementedException();
    }

    void test()
    {
        autoFlip.PageFlipTime = 0.2f;
        if (bookPro.CurrentPaper >=7)
        {
            bookPro.CurrentPaper = 3;
        }
        autoFlip.FlipRightPage();
        
    }
    void test3()
    {

        Camera.main.transform.position += new Vector3(0, 0, 0.4f);
        BlackScreen.color += new Color(0, 0, 0, 0.02f);
    }
}
