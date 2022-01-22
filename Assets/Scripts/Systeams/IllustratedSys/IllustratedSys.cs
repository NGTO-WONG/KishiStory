using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustratedSys : MonoBehaviour
{
    public static IllustratedSys instance = null;
    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        try
        {
            GameObject.Find("Image_Adventy").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_illustrated").GetComponent<Animator>().Play("Selected");
            GameObject.Find("Image_Eqp").GetComponent<Animator>().Play("Normal");
            GameObject.Find("Image_Chara").GetComponent<Animator>().Play("Normal");
        }
        catch
        {
            Debug.Log("bottomBtnsError");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
