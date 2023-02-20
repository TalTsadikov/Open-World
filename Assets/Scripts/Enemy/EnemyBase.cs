using UnityEngine;

public abstract class EnemyBase
{
    public abstract void EnterState(Enemy behavior);
    public abstract void UpdateState(Enemy behavior);
}
