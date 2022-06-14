using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5.0f;

    private Character owner;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.velocity = transform.forward * moveSpeed;

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup (Character character)
    {
        owner = character;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character hit = other.GetComponent<Character>();

        if(hit != owner & hit != null)
        {
            hit.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
