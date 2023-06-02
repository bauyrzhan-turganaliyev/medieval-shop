using UnityEngine;

public class DestinationsData : MonoBehaviour
{
    [SerializeField] private Transform _trade;
    [SerializeField] private Transform _production;
    [SerializeField] private Transform _polish;
    [SerializeField] private Transform _make;

    public Vector3 GetPosition(EMode mode)
    {
        switch (mode)
        {
            case EMode.Make:
                return _make.position;
            case EMode.Trade:
                return _trade.position;
            case EMode.Production:
                return _production.position;
            case EMode.Polish:
                return _polish.position;
        }

        return _trade.position;
    }
}