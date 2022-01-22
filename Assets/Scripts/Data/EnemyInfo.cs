using System;
using UnityEngine;

public class EnemyInfo : CharaInfo
{
    public int id;
    public int name;
    public int level;
    public BallType weakBallType;
    public int attackCounter;
    public int nowAttackCounter;
    public float element_weighting;
    public string enterWord;
    public EnemyInfo GetClone()
    {
        EnemyInfo tempInfo= new EnemyInfo();
        tempInfo.hp = this.hp;
        tempInfo.id = this.id;
        tempInfo.name = this.name;
        tempInfo.level = this.level;
        tempInfo.element_weighting = this.element_weighting;

        tempInfo.atk = this.atk;
        tempInfo.def = this.def;
        tempInfo.objPath = this.objPath;
        tempInfo.attackCounter = this.attackCounter;
        tempInfo.nowAttackCounter = this.attackCounter;
        tempInfo.weakBallType = this.weakBallType;
        tempInfo.enterWord = this.enterWord;
        return tempInfo;
    }
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }


    public override void Die()
    {
        base.Die();
        animator.SetBool("die", true);
        bool tempbool = true;
        MonoMgr.GetInstance().AddUpdateListener(() =>
        {
            try
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("death") && (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) && tempbool)
                {
                    tempbool = false;
                    EventCenter.GetInstance().EventTrigger(EventDic.EnemyDie);
                    obj.SetActive(false);
                }
            }
            catch
            {

            }
        });
    }

    public override void Attack()
    {
        Debug.Log("attack");
        base.Attack();
        animator.Play("attack");
    }
    public  void GetHit(int Pre_taxDamage,AttackInfo attackInfo)
    {
        int atk = Pre_taxDamage;
        float sizeBuff = GameConfig.swordSize(attackInfo.ballLevel);
        float weight = attackInfo.weight;
        if (attackInfo.ballType == weakBallType)
        {
            weight *= element_weighting;
        }
        if (weight == 0) weight = 1;
        if (attackInfo.ballType == BallType.sword)
        {
            weight = 1;
        }

        Debug.Log(atk + "atk");
        Debug.Log(sizeBuff + "sizeBuff");
        Debug.Log(weight + "weight");
        Debug.Log(def + "def");
        float damage = atk * sizeBuff * weight - def;


        if (damage <= 0) damage = 1;


        int after_taxDamage =    (int) Math.Ceiling(damage);

         LogSvc.GetInstance().SaveLog1(attackInfo.ballA, attackInfo.ballASize,attackInfo.ballB,attackInfo.ballBSize, "1", damage.ToString());


        UIManager.GetInstance().ShowPanel<DamageNumber>("DamageNumber", E_UI_Layer.Top, (script) =>
        {
            script.Init(obj.transform, after_taxDamage);
        });
        hp -= after_taxDamage;
        if (hp <= 0)
        {
            Die();
            Debug.Log(objPath + "  die");
        }

        EventCenter.GetInstance().AddEventListener(EventDic.EnemyHitAnimation, PlayHit);
    }

    public void PlayHit()
    {
        animator.Play("hit");
        //throw new NotImplementedException();
    }
}
