using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour  //ABSTRACTION + INHERITANCE
{
    [Header("Stats")]
    public int CurHp;
    public int MaxHp;

    [Header("Components")]
    public CharacterController Controller;
    protected Character target;  //ENCAPSULATION within INHERITANCE

    public event UnityAction onTakeDamage;

    // Start is called before the first frame update
    void Start()  //INHERITED ABSTRACTION
    {
        
    }

    // Update is called once per frame
    void Update()  //INHERITED ABSTRACTION
    {
        
    }

    // all Characters need to be able to take damage
    public void TakeDamage(int damageToTake)  //ABSTRACTION
    {
        CurHp -= damageToTake;
        onTakeDamage?.Invoke();  //INHERITED ABSTRACTION

        // and die if they loose all their health
        if (CurHp <= 0)
            Die();  //ABSTRACTION used POLYMORPHICALLY
    }

    // all Characters need to be able to die but death is handled differently between Player Characters and NPCs/Enemies
    public virtual void Die ()  //POLYMORPHISM
    {
        Destroy(gameObject);  //INHERITED ABSTRACTION from namespace
    }

    // Players and Enemies need to be able to choose a target and try to do stuff to that target
    public void SetTarget (Character t)  //ABSTRACTION
    {
        target = t;
    }
}
