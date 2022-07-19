using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    int playerHealth = 100,x, y = 1;
    Color noDamage;

    GameManager gmInstance;
    bool isLeft = false;
    bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        noDamage = GetComponent<Renderer>().material.color;
        gmInstance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }
    public void GoingLeft()
    {
        isLeft = true;
    }
    public void NotGoingLeft()
    {
        isLeft = false;
    }
    public void GoingRight()
    {
        isRight = true;
    }
    public void NotGoingRight()
    {
        isRight = false;
    }
    void MyInput()
    {
        if (Physics2D.gravity.y > 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        if (isLeft)
        {
            y = -1;
            rb.velocity = new Vector2(-moveSpeed * x, rb.velocity.y);
        }
        if (isRight)
        {
            y = 1;
            rb.velocity = new Vector2(moveSpeed * x, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.F) && !LeanTween.isTweening(gameObject) && rb.velocity.y == 0f && transform.parent == null)
        {
            LeanTween.move(gameObject, new Vector3(transform.position.x + (1.2f * y * x), transform.position.y, transform.position.z), 0.3f).setEasePunch();
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                gmInstance.GetHit();
                if(gmInstance.enemyHealth <= 0)
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }

    void TakeDamage()
    {
        playerHealth -= 1;
        FindObjectOfType<GameManager>().GetComponent<GameManager>().DisplayHealth(playerHealth);
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        if(playerHealth<=0)
        {

            FindObjectOfType<GameManager>().GetComponent<GameManager>().RestartLevel();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Renderer>().material.color = noDamage;
        }
    }

}
