

public class TestSkill : SkillBase
{
    public override void Init()
    {
        skillType = SkillType.passivity;
        skillID = 1;
        skillLevel = 1;
        skillDescript = "���Լ���1";
    }

    public override void SkillFunc()
    {
        UnityEngine.Debug.Log("���Լ���");
        //throw new System.NotImplementedException();
    }

    public override void SkillLevelUp()
    {
        //throw new System.NotImplementedException();
    }
}
