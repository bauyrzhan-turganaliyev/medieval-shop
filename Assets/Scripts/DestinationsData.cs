
using DefaultNamespace;
using UnityEngine;

public class DestinationsData : MonoBehaviour
{
    [SerializeField] private Transform _trade;
    [SerializeField] private Transform _production;
    [SerializeField] private Transform _polish;
    [SerializeField] private Transform _make;

    public Vector3 GetPosition(EDestionation destionation)
    {
        switch (destionation)
        {
            case EDestionation.Make:
                return _make.position;
            case EDestionation.Trade:
                return _trade.position;
            case EDestionation.Production:
                return _production.position;
            case EDestionation.Polish:
                return _polish.position;
        }

        return _trade.position;
    }
}