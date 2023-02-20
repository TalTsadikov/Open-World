using UnityEngine;

public class EnemyAttack : EnemyBase
{
    public override void EnterState(Enemy behavior)
    {
    }
    public override void UpdateState(Enemy behavior)
    {
        Debug.Log("Attack");
        behavior.agent.SetDestination(behavior.target);
    }
}
