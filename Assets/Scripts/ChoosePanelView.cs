using System;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanelView : MonoBehaviour
{
    [SerializeField] private ChooseWeaponView _chooseWeaponView;
    [SerializeField] private ChooseArmorView _chooseArmorView;
    [SerializeField] private ChooseExpendablesView _chooseExpendablesView;
    
    [SerializeField] private Button _weaponButton;
    [SerializeField] private Button _armorButton;
    [SerializeField] private Button _expendablesButton;

    public Action<ItemClass> OnItemChosen;
    
    private ChooseView _chooseView;
    
    public void Init()
    {
        _chooseWeaponView.Init();
        _chooseWeaponView.OnItemClicked += ItemChosen;  
        
        _chooseArmorView.Init();
        _chooseArmorView.OnItemClicked += ItemChosen;  
        
        _chooseExpendablesView.Init();
        _chooseExpendablesView.OnItemClicked += ItemChosen;  
        
        _weaponButton.onClick.AddListener(() =>
        {
            CloseView();
            _chooseView = _chooseWeaponView;
            _chooseView.gameObject.SetActive(true);
        });
        
        _armorButton.onClick.AddListener(() =>
        {
            CloseView();
            _chooseView = _chooseArmorView;
            _chooseView.gameObject.SetActive(true);
        });
        
        _expendablesButton.onClick.AddListener(() =>
        {
            CloseView();
            _chooseView = _chooseExpendablesView;
            _chooseView.gameObject.SetActive(true);
        });
    }

    private void ItemChosen(ItemClass obj)
    {
        OnItemChosen?.Invoke(obj);
    }

    private void CloseView()
    {
        if (_chooseView != null) _chooseView.gameObject.SetActive(false);
    }
}