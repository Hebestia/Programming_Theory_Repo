using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private Character character;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthbar;
    }

    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthbar;
    }

    void UpdateHealthbar ()
    {
        healthFill.fillAmount = (float)character.CurHp / (float)character.MaxHp;
    }
}
