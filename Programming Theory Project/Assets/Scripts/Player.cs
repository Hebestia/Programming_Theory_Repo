using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character  //INHERITANCE
{
    // more ENCAPSULATION with visibility in editor
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private GameObject attackPrefab;
    private float lastAttackTime;
    
    // singleton design pattern, could use some more encapsulation
    public static Player Current;

    private void Awake()  //INHERITED ABSTRACTION
    {
        // proper way to ensure single instance of singleton in C#/Unity
        if (Current != null && Current != this)
            Destroy(this.gameObject);
        else 
            Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        // do things if you have a target, even if the target is a spot on the ground
        if(target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);  //ABSTRACTION

            if(targetDistance < attackRange)
            {
                // stop and face the music
                Controller.StopMovement();  //ABSTRACTION
                Controller.LookTowards(target.transform.position - transform.position);  //ABSTRACTION

                // you can only attack so often
                if(Time.time - lastAttackTime > attackRate)
                {
                    lastAttackTime = Time.time;
                    GameObject proj = Instantiate(attackPrefab, transform.position + Vector3.up, Quaternion.LookRotation(target.transform.position - transform.position));  //ABSTRACTION
                    proj.GetComponent<Projectile>().Setup(this);  //ABSTRACTION
                }
            }
            else
            {
                Controller.MoveToTarget(target.transform);  //ABSTRACTION
            }
        }
    }

    // Permadeath, probably not the best UX choice but that's what we are doing for now
    public override void Die()  //POLYMORPHISM
    {
        Debug.Log("Player dies, eventually we watch a death animation and play an ugly sound and then end the game?");
        Manager.Instance.EndGame();  //ABSTRACTION
    }
}
