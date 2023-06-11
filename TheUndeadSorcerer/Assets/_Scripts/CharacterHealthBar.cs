using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    private Slider healthBar;

    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        _health.OnDamageDealt += HealthBarValue;
    }
    public void HealthBarValue()
    {
        healthBar.value = (float)_health.health / _health.maxHealth;
    }
}
