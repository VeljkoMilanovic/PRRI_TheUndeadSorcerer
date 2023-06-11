using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private Animator animator;
    private Character character;

    [HideInInspector] public float health;
    public float maxHealth;
    public Action OnDamageDealt;

    [SerializeField] GameObject ragdoll;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = character.mainCharacterStats.health;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveHealth(float damageTaken)
    {
        health -= damageTaken;
        OnDamageDealt?.Invoke();
        Debug.Log(health);

        if (health > 0)
        {
            animator.SetTrigger("damage");
            character.characterSound.PlayHitClip();
        }
        else if (health <= 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        character.characterSound.PlayDeathClip();
        Destroy(this.gameObject);
        Instantiate(ragdoll, transform.position, transform.rotation);
        GameManager.Instance.GameOver();
    }
}
