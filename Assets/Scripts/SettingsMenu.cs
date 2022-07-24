using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;
    [SerializeField] private Toggle quickRestartToggle;
    [SerializeField] private AudioMixer audioMixer;
    private void Awake()
    {
        audioToggle.isOn = PLayerRepo.Sound;
        quickRestartToggle.isOn = PLayerRepo.QuickRestart;
    }

    public void OnAudioToggleValueChange(bool value)
    {
        PLayerRepo.Sound = audioToggle.isOn;
        if(audioToggle.isOn)
            audioMixer.SetFloat("masterVolume", 0);
        else
            audioMixer.SetFloat("masterVolume", -80);
    }
    public void OnRestartToggleValueChange(bool value)
    {
        PLayerRepo.QuickRestart = quickRestartToggle.isOn;
    }
}
