using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private AudioClip sound;

    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        ForAudioManager.Audio.PlaySound(sound);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
        ForAudioManager.Audio.PlaySound(sound);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        Debug.Log("Speed: " + speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    public void OnSoundToggle()
    {
        ForAudioManager.Audio.soundMute = !ForAudioManager.Audio.soundMute;
        ForAudioManager.Audio.PlaySound(sound);
    }

    public void OnSoundValue(float volume)
    {
        ForAudioManager.Audio.soundVolume = volume;
    }

    public void OnMusicToggle()
    {
        ForAudioManager.Audio.musicMute = !ForAudioManager.Audio.musicMute;
        ForAudioManager.Audio.PlaySound(sound);
    }

    public void OnMusicValue(float volume)
    {
        ForAudioManager.Audio.musicVolume = volume;
    }

    public void OnPlayMusic(int selector)
    {
        ForAudioManager.Audio.PlaySound(sound);

        switch(selector)
        {
            case 1:
                ForAudioManager.Audio.PlayIntroMusic();
                break;
            case 2:
                ForAudioManager.Audio.PlayLevelMusic();
                break;
            default:
                ForAudioManager.Audio.StopMusic();
                break;
        }
    }
}
