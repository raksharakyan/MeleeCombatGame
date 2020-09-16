using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    CHASE,
    ATTACK
}
public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimations enemyAnimation;
    private NavMeshAgent navMesh;
    private Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float attackDistance = 1.5f;
    public float chasePlayerAfterAttack = 1f;
    private float waitBeforeAttackTime = 3f;
    private float attackTimer = 0f;

    private EnemyState enemyState;
    void Awake()
    {
        enemyAnimation = GetComponent<CharacterAnimations>();
        navMesh = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        enemyState = EnemyState.CHASE;
        attackTimer =  waitBeforeAttackTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(enemyState == EnemyState.CHASE)
           { ChasePlayer(); }
        if(enemyState == EnemyState.ATTACK)
           {  AttackPlayer(); }
    }
    void ChasePlayer()
    {
        navMesh.SetDestination(playerTarget.position);
        navMesh.speed = moveSpeed;
        if(navMesh.velocity.sqrMagnitude == 0)
        {
            enemyAnimation.Walk(false);
        }
        else
        {
            enemyAnimation.Walk(true);
        }

        if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            
            enemyState = EnemyState.ATTACK;
        }
    }
    void AttackPlayer()
    {
        navMesh.velocity = Vector3.zero;
        navMesh.isStopped = true;
        enemyAnimation.Walk(false);

        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttackTime)
        {
            enemyAnimation.Melee();

            attackTimer = 0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            navMesh.isStopped = false;
            enemyState =  EnemyState.CHASE;
        }
       
    }
}
