using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] private float weaponLength;

    private Character character;
    private float weaponDamage;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if(Physics.SphereCast(transform.position, weaponLength, transform.forward, out hit, weaponLength, layerMask))
            {
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    if (character.isBasicAttack && !character.isSpecialAttack)
                    {
                        weaponDamage = character.mainCharacterStats.basicAttackDamage;
                        enemy.RemoveHealth(weaponDamage);
                        hasDealtDamage.Add(hit.transform.gameObject);
                    }
                    else if (character.isSpecialAttack && !character.isBasicAttack)
                    {
                        weaponDamage = character.mainCharacterStats.specialAttackDamage;
                        enemy.RemoveHealth(weaponDamage);
                        hasDealtDamage.Add(hit.transform.gameObject);
                    }
                    else
                    {
                        weaponDamage = 0f;
                    }
                }
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, weaponLength);
    }
}
