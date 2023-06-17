using TMPro;
using UnityEngine;

public class ItemVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _materialTextPrefab;
    [SerializeField] private TMP_Text _quality;

    [SerializeField] private Transform _materialParent;

    public void Setup(Item item)
    {
        _name.text = item.ItemClass.ToString();

        foreach (var resource in item.Resources)
        {
            var text = Instantiate(_materialTextPrefab, _materialParent);
            switch (resource.Resource)
            {
                case EResource.PolishedWood:
                    text.text = "Wood";
                    break;
                case EResource.PolishedStone:
                    text.text = "Stone";
                    break;
                case EResource.PolishedIron:
                    text.text = "Iron";
                    break;
                case EResource.PolishedLeather:
                    text.text = "Leather";
                    break;
                case EResource.PolishedSilver:
                    text.text = "Silver";
                    break;
                case EResource.PolishedGold:
                    text.text = "Gold";
                    break;
                case EResource.PolishedAlchemicalIngredient:
                    text.text = "Alchemical i.";
                    break;
                case EResource.PolishedMagicCrystal:
                    text.text = "Magic cst.";
                    break;
                case EResource.PolishedTitan:
                    text.text = "Titan";
                    break;
                case EResource.PolishedLunocit:
                    text.text = "Lunocit";
                    break;
            }
        }

        _quality.text = item.ItemQuality.ToString();
    }
}