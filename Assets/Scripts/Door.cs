using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameManager gmInstance;
    void Start()
    {
        gmInstance = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gmInstance.CompleteLevel();
        }
    }
}
