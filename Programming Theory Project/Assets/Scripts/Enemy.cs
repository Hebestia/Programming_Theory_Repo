using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character  //INHERITANCE
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State curState = State.Idle;

    //ENCAPSULATION with benefit of visibility in Unity Editor
    [Header("Ranges")]
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;

    [Header("Attack")]
    [SerializeField] private float attackRate;
    [SerializeField] private GameObject attackPrefab;
    private float lastAttackTime;

    private float targetDistance;

    // Start is called before the first frame update
    void Start()  //INHERITED ABSTRACTION
    {
        //initialize parent variable player reference
        target = Player.Current;
    }

    // Update is called once per frame
    void Update()  //INHERITED ABSTRACTION
    {
        // if you do not have a target do not do anything
        if (target == null)
            return;
        
        // watch your target and..
        targetDistance = Vector3.Distance(transform.position, target.transform.position);

        // do things depending on your state
        switch(curState)
        {
            case State.Idle:
                IdleUpdate();  //ABSTRACTION
                break;
            case State.Attack:
                AttackUpdate();  //ABSTRACTION
                break;
            case State.Chase:
                ChaseUpdate();  //ABSTRACTION
                break;
        }
    }

    void SetState (State newState)  //ABSTRACTION
    {
        // change state
        curState = newState;

        // do things depending on your new state
        switch (curState)
        {
            case State.Idle:
                Controller.StopMovement();  //ABSTRACTION
                break;
            case State.Chase:
                Controller.MoveToTarget(target.transform);  //ABSTRACTION
                break;
            case State.Attack:
                Controller.StopMovement();  //ABSTRACTION
                break;
        }
    }

    // Called every frame while in the IDLE state, state transitions from IDLE state
    void IdleUpdate()  //ABSTRACTION
    {
        if (targetDistance < chaseRange && targetDistance > attackRange)
            SetState(State.Chase);  //ABSTRACTION
        else if (targetDistance <= attackRange)
            SetState(State.Attack);  //ABSTRACTION
    }

    // Called every frame while in the CHASE state, state transitions from CHASE state
    void ChaseUpdate()  //ABSTRACTION
    {
        if (targetDistance > chaseRange)
            SetState(State.Idle);  //ABSTRACTION
        else if (targetDistance <= attackRange)
            SetState(State.Attack);  //ABSTRACTION
    }

    // Called very frame while in the ATTACK state, state transitions from ATTACK state
    void AttackUpdate()  //ABSTRACTION
    {
        if (targetDistance > attackRange)
            SetState(State.Chase);  //ABSTRACTION

        // face your enemy
        Controller.LookTowards(target.transform.position - transform.position);

        // you can only attack so fast -> so many times per unit time
        if(Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            AttackTarget();  //ABSTRACTION
        }
    }

    // Create a projectile and shoot it at the target
    void AttackTarget()
    {
        // pew pew
        GameObject proj = Instantiate(attackPrefab, transform.position + Vector3.up, Quaternion.LookRotation(target.transform.position - transform.position));  //ABSTRACTION
        proj.GetComponent<Projectile>().Setup(this);  //ABSTRACTION
    }

    public override void Die()  //POLYMORPHISM
    {
        Debug.Log("Enemy dies, eventually we will gain XP, watch a die animation, and play a death rattle");
        base.Die();
    }
}
