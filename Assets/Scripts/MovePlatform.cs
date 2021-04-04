using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
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
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
