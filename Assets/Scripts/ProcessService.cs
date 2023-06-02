using UnityEngine;

public class ProcessService : MonoBehaviour
{
    [SerializeField] private ProductionService _productionService;
    private PlayerProgress _playerProgress;

    public void Init(PlayerProgress playerProgress)
    {
        _playerProgress = playerProgress;
        _productionService.Init(_playerProgress.ResourcesData, _playerProgress.ProductionSkillData);
    }
}