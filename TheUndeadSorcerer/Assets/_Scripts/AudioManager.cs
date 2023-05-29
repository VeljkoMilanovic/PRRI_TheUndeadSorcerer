using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource mainCharacterSFXSource;
    [SerializeField] private AudioSource enemySFXSource;

    [Header("Audio Volume Sliders")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    [Header("Mute Buttons")]
    [SerializeField] private TextMeshProUGUI masterMuteButtonText;
    [SerializeField] private TextMeshProUGUI musicMuteButtonText;
    [SerializeField] private TextMeshProUGUI SFXMuteButtonText;

    public void ChangeMasterVolume()
    {
        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    public void ChangeMusicVolume()
    {
        musicAudioSource.volume = musicVolumeSlider.value * masterVolumeSlider.value;
    }

    public void ChangeSFXVolume()
    {
        mainCharacterSFXSource.volume = SFXVolumeSlider.value * masterVolumeSlider.value;
        enemySFXSource.volume = SFXVolumeSlider.value * masterVolumeSlider.value;
    }
}
