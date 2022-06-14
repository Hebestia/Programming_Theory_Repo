using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private GameObject attackPrefab;
    private float lastAttackTime;
    
    public static Player Current;

    private void Awake()
    {
        if (Current != null && Current != this)
            Destroy(this.gameObject);
        else 
            Current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);

            if(targetDistance < attackRange)
            {
                Controller.StopMovement();
                Controller.LookTowards(target.transform.position - transform.position);

                if(Time.time - lastAttackTime > attackRate)
                {
                    lastAttackTime = Time.time;
                    GameObject proj = Instantiate(attackPrefab, transform.position + Vector3.up, Quaternion.LookRotation(target.transform.position - transform.position));
                    proj.GetComponent<Projectile>().Setup(this);
                }
            }
            else
            {
                Controller.MoveToTarget(target.transform);
            }
        }
    }
}
