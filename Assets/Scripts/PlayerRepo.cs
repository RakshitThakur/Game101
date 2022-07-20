using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Practice, Online , None}
public class PLayerRepo
{
    // 0 = false, 1 = true
    public static float time = 0;
    
    public static GameMode CurrentGameMode = GameMode.None;
    public static bool Sound { get { return Convert.ToBoolean(PlayerPrefs.GetInt("Sound", 1)); } set { PlayerPrefs.SetInt("Sound", Convert.ToInt32(value)); } }
    public static bool QuickRestart { get { return Convert.ToBoolean(PlayerPrefs.GetInt("QuickRestart", 0)); } set { PlayerPrefs.SetInt("QuickRestart", Convert.ToInt32(value)); } }
}
