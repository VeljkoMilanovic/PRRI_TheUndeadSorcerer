using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] AudioSource playerSoundSource;
    [SerializeField] AudioClip playerAttackClip;
    [SerializeField] AudioClip playerJumpAttackClip;
    [SerializeField] AudioClip playerHitClip;
    [SerializeField] AudioClip playerDeathClip;

    public void PlayAttackClip()
    {
        playerSoundSource.clip = playerAttackClip;
        playerSoundSource.Play();
    }
    
    public void PlayJumpAttackClip()
    {
        playerSoundSource.clip = playerJumpAttackClip;
        playerSoundSource.Play();
    }

    public void PlayHitClip()
    {
        playerSoundSource.clip = playerHitClip;
        playerSoundSource.Play();
    }

    public void PlayDeathClip()
    {
        playerSoundSource.clip = playerDeathClip;
        playerSoundSource.Play();
    }
}
