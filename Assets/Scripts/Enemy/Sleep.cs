using UnityEngine;

public class Sleep : EnemyBase
{
    public override void EnterState(Enemy behavior)
    {
    }
    public override void UpdateState(Enemy behavior)
    {
        Debug.Log($"sleep");
        behavior.agent.SetDestination(behavior.target);
    }
}
