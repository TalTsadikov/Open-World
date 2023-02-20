using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{

    public Collider[] targetsView;
    public GameObject player;

    EnemyBase currentState;
    EnemyAttack enemyAttack = new EnemyAttack();
    Sleep enemySleep = new Sleep();

    [Header("Patrol mode")]
    public float viewRadius;
    public Vector3 target;
    public NavMeshAgent agent;

    private void Start()
    {
        agent = this.transform.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform.position;
        currentState = enemySleep;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
        ViewTargets();

        if(targetsAttack.Length>0)
        {
            attack = true;
            if (copydelay <= 0)
            {
                copydelay = 0;
                CoolDown();
            }
            else
            {
                copydelay -= Time.deltaTime;
            }
        }
        else if(targetsView.Length>0)
        {
            attack = false;
            target = player.transform.position;
            CheckDist();
            currentState = enemyAttack;
        }
        else
        {
            attack = false;
            target = this.transform.position;
            currentState = enemySleep;
        }
    }
    public void ViewTargets()
    {
        targetsView= Physics.OverlapSphere(transform.position, viewRadius, enemyLayer);
    }
}
