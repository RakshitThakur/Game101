using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoy : MonoBehaviour
{
    public GameObject circleBoy;

    private void Start()
    {
        circleBoy.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            circleBoy.SetActive(true);
        }
    }
}
