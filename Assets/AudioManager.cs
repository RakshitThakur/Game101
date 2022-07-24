using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private void Awake()
    {
        if(PLayerRepo.Sound)
        {
            audioMixer.SetFloat("masterVolume", 0);
        }
        else
        {
            audioMixer.SetFloat("masterVolume", -80);
        }
    }
}
