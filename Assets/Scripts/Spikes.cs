using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    GameManager gmInstance;
    void Start()
    {
        gmInstance = GameManager.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           gmInstance.RestartLevel();
        }
    }
}
