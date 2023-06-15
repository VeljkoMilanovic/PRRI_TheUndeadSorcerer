using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] AudioSource playerSoundSource;
    [SerializeField] List<AudioClip> playerAttackClips;
    [SerializeField] AudioClip playerJumpAttackClip;
    [SerializeField] AudioClip playerHitClip;
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] List<AudioClip> playerFootstepsClips;

    private float timePassed;

    public void PlayAttackClip()
    {
        int randomAttackClip = Random.Range(0, playerAttackClips.Count - 1);
        playerSoundSource.PlayOneShot(playerAttackClips[randomAttackClip]);
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

    public void PlayFootstepsClip()
    {
        int randomFootstepsClip = Random.Range(0, playerFootstepsClips.Count - 1);
        playerSoundSource.PlayOneShot(playerFootstepsClips[randomFootstepsClip]);
    }
}
