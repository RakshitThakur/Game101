using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }
    private void FixedUpdate()
    {
       
    }
    void MyInput()
    {
        int x;
        if (Physics2D.gravity.y > 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed * x, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed * x, rb.velocity.y);
        }
    }
}
