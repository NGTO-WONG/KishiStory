using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStar : MonoBehaviour
{
    public void Init(int star)
    {
        if (star >= 3) star = 3;
        for (int i = 0; i < star; i++)
        {
            Stars[i].gameObject.SetActive(true);
        }

        Invoke("ShowAnimation", 2f);    
    }




    void ShowAnimation()
    {

        GetComponent<Animator>().Play("BtnStar");
    }
    public GameObject[] Stars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        }
    }
}
