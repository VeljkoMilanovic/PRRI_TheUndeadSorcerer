using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator animator;

    public float health = 100f;
    [SerializeField] GameObject ragdoll;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveHealth(float damageTaken)
    {
        health -= damageTaken;
        Debug.Log(health);

        if (health > 0)
        {
            animator.SetTrigger("damage");
        }
        else if (health <= 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
        Instantiate(ragdoll, transform.position, transform.rotation);
    }
}
