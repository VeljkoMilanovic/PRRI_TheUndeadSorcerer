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

            InstantiateSpecialAttackFX();

        }
    }

    public void InstantiateSpecialAttackFX()
    {
        int groundLayerMask = 1 << 10;
        Vector3 positionCorrection = new Vector3(0f, 0.05f, 0f);
        Vector3 rotationCorrection = new Vector3(90f, 0f, 0f);
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, weaponLength * 1.5f, transform.forward, out hit, weaponLength * 1.5f, groundLayerMask))
        {
            if (hit.transform.TryGetComponent(out Terrain terrain))
            {
                if (character.isSpecialAttack && !character.isBasicAttack)
                {
                    Debug.Log("teren");
                    Instantiate(character.mainCharacterStats.specialAttackDecal, hit.point + positionCorrection, Quaternion.identity * Quaternion.Euler(rotationCorrection));
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
