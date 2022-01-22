using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("aaaa");
            EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaEnemyAttack);
            //EventCenter.GetInstance().EventTrigger(EventDic.ca);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("aaaa");

            EventCenter.GetInstance().EventTrigger(EventDic.ControllAreaEnemyAttack);
            //EventCenter.GetInstance().EventTrigger(EventDic.ca);
        }
    }
}
