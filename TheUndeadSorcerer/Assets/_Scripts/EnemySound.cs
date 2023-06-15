using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] AudioSource enemySoundSource;
    [SerializeField] AudioClip enemyAttackClip;
    [SerializeField] AudioClip enemyHitClip;
    [SerializeField] AudioClip enemyDeathClip;

    private void Awake()
    {
        enemySoundSource = FindObjectOfType<EnemySFXSource>().GetComponent<AudioSource>();
    }

    public void PlayAttackClip()
    {
        enemySoundSource.clip = enemyAttackClip;
        enemySoundSource.Play();
    }

    public void PlayHitClip()
    {
        enemySoundSource.clip = enemyHitClip;
        enemySoundSource.Play();
    }

    public void PlayDeathClip()
    {
        enemySoundSource.clip = enemyDeathClip;
        enemySoundSource.Play();
    }
}
