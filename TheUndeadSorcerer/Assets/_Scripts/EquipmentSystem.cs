using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] GameObject currentWeaponInHand;
    [SerializeField] GameObject currentWeaponInSheath;
    void Start()
    {
        currentWeaponInHand.SetActive(false);
    }

    public void DrawWeapon()
    {
        currentWeaponInHand.SetActive(true);
        currentWeaponInSheath.SetActive(false);
    }

    public void SheathWeapon()
    {
        currentWeaponInHand.SetActive(false);
        currentWeaponInSheath.SetActive(true);
    }

    public void StartDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }
}