
using System;
//using System.Diagnostics;
using Unity;
using UnityEngine;

public class CharaInfo
{
    public string objPath;
    public int hp;
    public int atk;
    public int def;
    public GameObject obj;
    public Animator animator;

    public virtual void Attack()
    {
        //return atk;
    }
    
    public virtual void GetHit(int Pre_taxDamage)
    {
        int after_taxDamage = Pre_taxDamage - def;
        if (after_taxDamage <= 0)
        {
            after_taxDamage = 1;
        }
        UIManager.GetInstance().ShowPanel<DamageNumber>("DamageNumber", E_UI_Layer.Top, (script) =>
          {
              script.Init(obj.transform, after_taxDamage);
          });
        hp -= after_taxDamage;
        if (hp <= 0) 
        { 
            Die();
            Debug.Log(objPath + "  die");

            EventCenter.GetInstance().EventTrigger(EventDic.PlayerDie);
            try
            {
                obj.GetComponent<Animator>().SetBool("die", true);

            }
            catch
            {

            }
        }
    }

    public virtual void Die()
    {
        //throw new NotImplementedException();
    }
}
