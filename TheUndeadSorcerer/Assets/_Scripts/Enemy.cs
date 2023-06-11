using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float health = 100;
    public float maxHealth = 100;
    [SerializeField] GameObject ragdoll;

    [Header("Combat")]
    [SerializeField] float attackCD = 5f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timePassed;
    float newDestinationCD = 0.5f;

    private EnemySound enemySound;

    public Action OnDamageDealt;

    private void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemySound = GetComponent<EnemySound>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);

        if (player == null)
        {
            return;
        }

        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange && player.GetComponent<Health>().health > 0)
            {
                animator.SetTrigger("attack");
                enemySound.PlayAttackClip();
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        Quaternion currentRotation = transform.rotation;
        transform.LookAt(player.transform);

        Quaternion desiredRotation = transform.rotation;

        desiredRotation.x = currentRotation.x;
        desiredRotation.z = currentRotation.z;

        transform.rotation = desiredRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print(true);
            player = collision.gameObject;
        }
    }

    public void RemoveHealth(float damageTaken)
    {
        health -= damageTaken;
        OnDamageDealt?.Invoke();
        Debug.Log(health);

        if (health > 0)
        {
            animator.SetTrigger("damage");
            enemySound.PlayHitClip();
        }
        else if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        enemySound.PlayDeathClip();
        Destroy(this.gameObject);
        Instantiate(ragdoll, transform.position, transform.rotation);
        GameManager.Instance.UpdateScore();
    }

    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}