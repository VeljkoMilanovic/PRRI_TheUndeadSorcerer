using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Character", menuName ="Game Character")]
public class GameCharacter : ScriptableObject
{
    public Sprite image;
    public new string name;
    public float health;
    public float basicAttackDamage;
    public float specialAttackDamage;
    public ParticleSystem specialAttackDecal;
}
