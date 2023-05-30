using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MasterPref = "MasterPref";
    private static readonly string BackgroundMusicPref = "BackgroundMusicPref";
    private static readonly string SFXPref = "SFXPref";
    private float masterFloat, backgroundMusicFloat, sfxFloat;
    private int firstPlayInt;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            masterFloat = masterVolumeSlider.value;
            backgroundMusicFloat = musicVolumeSlider.value;
            sfxFloat = SFXVolumeSlider.value;
            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(BackgroundMusicPref, backgroundMusicFloat);
            PlayerPrefs.SetFloat(SFXPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            masterFloat = PlayerPrefs.GetFloat(MasterPref);
            masterVolumeSlider.value = masterFloat;
            backgroundMusicFloat = PlayerPrefs.GetFloat(BackgroundMusicPref);
            musicVolumeSlider.value = backgroundMusicFloat;
            sfxFloat = PlayerPrefs.GetFloat(SFXPref);
            SFXVolumeSlider.value = sfxFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MasterPref, masterVolumeSlider.value);
        PlayerPrefs.SetFloat(BackgroundMusicPref, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(SFXPref, SFXVolumeSlider.value);
    }

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

    public void Mute(AudioSource audioSource)
    {
        audioSource.mute = !audioSource.mute;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject.gameObject;
        if (audioSource.mute == true)
        {
            clickedButton.GetComponentInChildren<TextMeshProUGUI>().text = "ON";
        }
        else
        {
            clickedButton.GetComponentInChildren<TextMeshProUGUI>().text = "OFF";
        }
    }
}
