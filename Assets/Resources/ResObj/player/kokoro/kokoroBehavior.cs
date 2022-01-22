using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kokoroBehavior : MonoBehaviour
{
    public void Attack()
    {
        EventCenter.GetInstance().EventTrigger(EventDic.EnemyHitAnimation);
    }
}
