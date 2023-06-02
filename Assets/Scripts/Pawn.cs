using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    public async Task MoveAndWaitAsync(Vector3 pointA)
    {
        _agent.SetDestination(pointA);

        // Wait until the waiter reaches point A
        await _agent.WaitForDestinationReachedAsync();
    }
    public async Task MoveAndWaitAsync(Vector3 pointA, CancellationToken cancellationToken = default)
    {
        _agent.SetDestination(pointA);

        // Wait until the waiter reaches point A
        await _agent.WaitForDestinationReachedAsync(cancellationToken);
    }
}
public static class NavMeshAgentExtensions
{
    public static async Task WaitForDestinationReachedAsync(this NavMeshAgent agent, CancellationToken cancellationToken)
    {
        while (agent.pathPending || agent.remainingDistance > 0.5f)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException(cancellationToken);
            }
                
            await Task.Yield();
        }
    }
    public static async Task WaitForDestinationReachedAsync(this NavMeshAgent agent)
    {
        while (agent.pathPending || agent.remainingDistance > 0.5f)
        {
            await Task.Yield();
        }
    }
}