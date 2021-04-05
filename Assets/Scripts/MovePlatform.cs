using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }
    void Oscillate()
    {
        if (transform.position !=  end.position && !LeanTween.isTweening(gameObject))
        {
            LeanTween.move(gameObject, end, 2f);
        }
        if (transform.position != start.position && !LeanTween.isTweening(gameObject))
        {
            LeanTween.move(gameObject, start, 2f);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
