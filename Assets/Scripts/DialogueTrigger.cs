using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    TypeWriter twInstance;

    private void Start()
    {
        twInstance = TypeWriter.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            twInstance.DisplayNextText();
            Destroy(this.gameObject);
        }
    }
}
