using UnityEngine;

public class ProcessService : MonoBehaviour
{
    [SerializeField] private ProductionService _productionService;
    [SerializeField] private PolishService _polishService;
    [SerializeField] private MakeService _makeService;
    
    private PlayerProgress _playerProgress;

    public void Init(PlayerProgress playerProgress)
    {
        _playerProgress = playerProgress;
        _productionService.Init(_playerProgress.ResourcesData, _playerProgress.ProductionSkillData);
        _polishService.Init(_playerProgress.ResourcesData, _playerProgress.PolishSkillData);
        _makeService.Init(_playerProgress);
    }
}