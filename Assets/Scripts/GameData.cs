using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    
    private void Awake()
    {   
       
        DontDestroyOnLoad(this.gameObject);
    }
    private static bool _firstFlip = true;
    public static bool firstFlip
    {
        get
        {
            return _firstFlip;
        }
        set
        {
            _firstFlip = value; 
        }
    }
    

}
