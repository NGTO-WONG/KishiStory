public class PlayerInfo : CharaInfo
{

    public int level;
    public int exp;
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

    public override void GetHit(int Pre_taxDamage)
    {
        animator.SetTrigger("hit");
        
        base.GetHit(Pre_taxDamage);

    }

    public  override void Die()
    {
        animator.SetBool("die",true);
        base.Die();
        //EventCenter.GetInstance().EventTrigger(EventDic.PlayerDie);




        //bool tempbool = true;
        //MonoMgr.GetInstance().AddUpdateListener(() =>
        //{

        //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("06_die") && (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) && tempbool)
        //    {
        //        tempbool = false;
        //        EventCenter.GetInstance().EventTrigger(EventDic.PlayerDie);
        //        //obj.SetActive(false);
        //    }
        //});

    }

    public void Win()
    {
        animator.SetTrigger("win");
    }

    public void Run()
    {
        animator.SetBool("run", true);
    }
    public void StopRun()
    {
        animator.SetBool("run", false);
    }
    public override void Attack()
    {
        animator.SetTrigger("attack");
        base.Attack();
        //atk = atk;


    }
}
