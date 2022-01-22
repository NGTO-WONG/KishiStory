using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => 
        {
            Debug.Log(transform.GetSiblingIndex());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
