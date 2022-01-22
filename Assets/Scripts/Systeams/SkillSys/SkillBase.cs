
public enum SkillType
{
    passivity,
    initiaive,
}

public abstract class SkillBase
{

    public SkillType skillType;
    public int skillID;
    public bool locked;
    public int skillLevel;
    public string skillDescript;
    public abstract void SkillFunc();
    public abstract void SkillLevelUp();
    public abstract void Init();
}
