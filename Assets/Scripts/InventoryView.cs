using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private ItemVisual _itemVisualPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Button _closeInventoryButton;
    
    private MessageBus _messageBus;
    private Inventory _inventory;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        _messageBus.OnInventoryUpdate += UpdateInventory;
        
        _closeInventoryButton.onClick.AddListener((() => gameObject.SetActive(false)));
    }

    public void Switch(bool flag)
    {
        gameObject.SetActive(flag);
    }
    
    private void UpdateInventory()
    {
        Clear();

        foreach (var item in _inventory.Items)
        {
            var itemVisual = Instantiate(_itemVisualPrefab, _parent);
            itemVisual.Setup(item);
        }
    }

    private void Clear()
    {
        for (int i = 0; i < _parent.childCount; i++)
        {
            Destroy(_parent.GetChild(i).gameObject);
        }
    }
}