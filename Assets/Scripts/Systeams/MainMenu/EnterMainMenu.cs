using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger("BookChange");
        });
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
