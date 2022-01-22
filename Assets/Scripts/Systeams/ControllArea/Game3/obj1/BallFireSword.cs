using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFireSword : BallBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);


        if (collision.collider.tag == "ball")
        {
            switch (collision.collider.gameObject.GetComponent<BallBase>().ballType)
            {
                case BallType.sword:
                    break;
                case BallType.hero:
                    break;
                case BallType.fire:
                    break;
                case BallType.firesword:
                    break;
                default:
                    break;
            }
        }
    }

}
