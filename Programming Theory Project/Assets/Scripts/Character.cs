using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [Header("Stats")]
    public int CurHp;
    public int MaxHp;

    [Header("Components")]
    public CharacterController Controller;
    protected Character target;

    public event UnityAction onTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageToTake)
    {
        CurHp -= damageToTake;
        onTakeDamage?.Invoke();

        if (CurHp <= 0)
            Die();
    }

    public void Die ()
    {
        Destroy(gameObject);
    }

    public void SetTarget (Character t)
    {
        target = t;
    }
}
