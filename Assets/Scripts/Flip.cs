using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    
    public void UpsideDown()
    {
       if(!LeanTween.isTweening(mainCamera) /*&& !GameData.firstFlip*/)
        {
            LeanTween.rotateAround(mainCamera, Vector3.forward, 180f, 0.5f).setEaseSpring();
            Physics2D.gravity = -Physics2D.gravity;
        }
    }
}
