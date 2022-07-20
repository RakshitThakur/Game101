using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;
    [SerializeField] private Toggle quickRestartToggle;

    public void OnAudioToggleValueChange(bool value)
    {
        PLayerRepo.Sound = value;
    }
    public void OnRestartToggleValueChange(bool value)
    {
        PLayerRepo.QuickRestart = value;
    }
}
