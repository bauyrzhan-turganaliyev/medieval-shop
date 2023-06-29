using System.Threading.Tasks;
using UnityEngine;

public class Customer : Pawn
{
    [SerializeField] private Animator _animator;

    private Order _order;
    private int _animationState;

    public void SetOrder(Order order)
    {
        _order = order;
    }

    public async Task MoveTo(Vector3 targetPointPosition)
    {
        _animationState = 0;
        
        _animator.SetInteger("state", _animationState);
        
        await MoveAndWaitAsync(targetPointPosition);

        _animationState = Random.Range(1, 3);
        
        _animator.SetInteger("state", _animationState);
    }

    public Order GetOrder()
    {
        return _order;
    }
}