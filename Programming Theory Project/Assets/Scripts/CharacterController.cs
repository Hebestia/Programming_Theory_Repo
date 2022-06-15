using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour  //INHERITANCE
{
    private float moveToUpdateRate = 0.1f;
    private float lastMoveToUpdate;
    private Transform moveTarget;

    private NavMeshAgent agent;

    private void Awake()  //INHERITED ABSTRACTION
    {
        // get agent reference so we can navigate in scene
        agent = GetComponent<NavMeshAgent>();  //INHERITED ABSTRACTION
    }

    // Update is called once per frame
    void Update()  //INHERITED ABSTRACTION
    {
        // if we have a target then move to it but don't do it every frame
        if (moveTarget != null && Time.time - lastMoveToUpdate > moveToUpdateRate)
        {
            lastMoveToUpdate = Time.time;
            MoveToPosition(moveTarget.position);  //ABSTRACTION
        }
    }

    public void LookTowards(Vector3 direction)  //ABSTRACTION
    {
        transform.rotation = Quaternion.LookRotation(direction);  //ABSTRACTION
    }

    public void MoveToTarget(Transform target)  //ABSTRACTION
    {
        moveTarget = target;
    }

    public void MoveToPosition(Vector3 position)  //ABSTRACTION
    {
        agent.isStopped = false;
        agent.SetDestination(position);  //ABSTRACTION
    }

    public void StopMovement()  //ABSTRACTION
    {
        agent.isStopped = true;
        moveTarget = null;
    }
}
