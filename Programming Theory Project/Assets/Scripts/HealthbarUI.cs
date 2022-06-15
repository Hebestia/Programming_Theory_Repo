using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour  //INHERITANCE
{
    [SerializeField] private Image healthFill;
    [SerializeField] private Character character;

    // Start is called before the first frame update
    void Start()  //INHERITED ABSTRACTION
    {
        UpdateHealthbar();  //ABSTRACTION
    }

    // Update is called once per frame
    void Update()  //INHERITED ABSTRACTION
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);  //ABSTRACTION
    }

    private void OnEnable()  //INHERITED ABSTRACTION
    {
        // start listening for this action
        character.onTakeDamage += UpdateHealthbar;  //ABSTRACTION
    }

    private void OnDisable()  //INHERITED ABSTRACTION
    {
        // stop listening for this action
        character.onTakeDamage -= UpdateHealthbar;  //ABSTRACTION
    }

    void UpdateHealthbar()  //ABSTRACTION
    {
        healthFill.fillAmount = (float)character.CurHp / (float)character.MaxHp;
    }
}
