

public class TestSkill : SkillBase
{
    public override void Init()
    {
        skillType = SkillType.passivity;
        skillID = 1;
        skillLevel = 1;
        skillDescript = "测试技能1";
    }

    public override void SkillFunc()
    {
        UnityEngine.Debug.Log("测试技能");
        //throw new System.NotImplementedException();
    }

    public override void SkillLevelUp()
    {
        //throw new System.NotImplementedException();
    }
}
