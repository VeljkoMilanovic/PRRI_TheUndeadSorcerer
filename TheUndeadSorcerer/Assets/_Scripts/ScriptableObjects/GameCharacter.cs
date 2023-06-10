using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Character", menuName ="Game Character")]
public class GameCharacter : ScriptableObject
{
    public new string name;
    public float health;
    public float basicAttackDamage;
    public float specialAttackDamage;
}
