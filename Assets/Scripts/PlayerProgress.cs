public class PlayerProgress
{
    public ResourcesData ResourcesData;
    public ProductionSkillData ProductionSkillData;
    public PolishSkillData PolishSkillData;

    public PlayerProgress()
    {
        ResourcesData = new ResourcesData();
        ProductionSkillData = new ProductionSkillData();
        PolishSkillData = new PolishSkillData();
    }
}