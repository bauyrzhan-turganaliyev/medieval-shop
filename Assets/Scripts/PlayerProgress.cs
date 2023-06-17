[System.Serializable]
public class PlayerProgress
{
    public ResourcesData ResourcesData;
    public ProductionSkillData ProductionSkillData;
    public PolishSkillData PolishSkillData;
    public Inventory Inventory;

    public PlayerProgress()
    {
        ResourcesData = new ResourcesData();
        ProductionSkillData = new ProductionSkillData();
        PolishSkillData = new PolishSkillData();
        Inventory = new Inventory();
    }
}