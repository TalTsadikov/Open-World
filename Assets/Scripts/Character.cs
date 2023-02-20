using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float Damage;
    public float HP;
    public float AttackRange;
    public float delay;
    public float copydelay;
    public bool Dead;
    public bool attack;
    public Collider[] targetsAttack;
    public LayerMask enemyLayer;


    public void TakeDamage(float damage) 
    {
        if(Dead==false)
        {
            HP-=damage;
            if(HP<=0)
            {
                Dead= true;
                Death();
            }
        }
    }
    public void Death()
    {
        this.transform.gameObject.SetActive(false);
    }
    public virtual void CheckDist()
    {
        targetsAttack = Physics.OverlapSphere(transform.position, AttackRange, enemyLayer);
    }

    public void CoolDown()
    {
        copydelay=delay;
        ApplyDamage();
    }

    public virtual void ApplyDamage() 
    {
        foreach (var character in targetsAttack)
        {
            Character enemy = character.transform.GetComponent<Character>();
            if (enemy != null)
            {
                Debug.Log("Hit!");
                enemy.TakeDamage(Damage);
            }
        }
    }
}
