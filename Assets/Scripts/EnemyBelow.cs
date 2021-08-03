using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBelow : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform start;
    [SerializeField] Transform end;
   
   
    int health = 100;
    //int x = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }
    private void LateUpdate()
    {
     
    }
    void Wander()
    {
        if (transform.position != end.position && !LeanTween.isTweening(gameObject))
        {
            
            LeanTween.move(gameObject, end, 3f);
            
        }
        if (transform.position != start.position && !LeanTween.isTweening(gameObject))
        {
            
            LeanTween.move(gameObject, start, 3f);
       
        }
    }
    public void GetHit()
    {
        health -= 20;
        Debug.Log(health);
        if(health<=0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
