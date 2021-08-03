using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    
    [SerializeField] GameObject mainCamera;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && GameData.firstFlip)
        {
            LeanTween.rotateAround(mainCamera, Vector3.forward, 180f, 0.5f).setEaseSpring();
            Physics2D.gravity = -Physics2D.gravity;
            GameData.firstFlip = false;
        }
    }

}
