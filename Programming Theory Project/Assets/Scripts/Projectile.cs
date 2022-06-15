using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour  //INHERITANCE
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5.0f;

    private Character owner;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()   //INHERITED ABSTRACTION
    {
        // initialize reference to physics component and shoot forward
        rig = GetComponent<Rigidbody>();  //ABSTRACTION
        rig.velocity = transform.forward * moveSpeed;

        // destroy after a small time has passed, might want to consider pooling to further optimize later
        Destroy(gameObject, lifetime);  //ABSTRACTION
    }

    public void Setup (Character character)  //ABSTRACTION
    {
        // get reference to shooter
        owner = character;
    }

    private void OnTriggerEnter(Collider other)  //ABSTRACTION
    {
        // get reference to Character base class that was hit by projectile
        Character hit = other.GetComponent<Character>();  //ABSTRACTION

        // don't shoot yourself and don't do anything if you didn't hit a Character base class, otherwise deal damage to the Character that was hit and destroy projectile, might want to consider pooling to optimize in the future
        if(hit != owner & hit != null)
        {
            hit.TakeDamage(damage);  //ABSTRACTION
            Destroy(gameObject);  //ABSTRACTION
        }
    }
}
