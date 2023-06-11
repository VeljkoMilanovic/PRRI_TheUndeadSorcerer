using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Enemy _enemy;
    private Slider healthBar;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        healthBar = gameObject.GetComponentInChildren<Slider>();
        _enemy.OnDamageDealt += HealthBarValue;
    }
    public void HealthBarValue()
    {
        healthBar.value = (float)_enemy.health / _enemy.maxHealth;
    }
}
