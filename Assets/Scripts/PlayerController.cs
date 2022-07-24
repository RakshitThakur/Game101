using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject pausedPanel;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI timer2Text;
    [SerializeField] TextMeshProUGUI timer3Text;
    [SerializeField] GameObject gameplayHUD;
    [SerializeField] GameObject deathPanel;
    int playerHealth = 100,x, y = 1;
    Color noDamage;

    GameManager gmInstance;

    bool isLeft = false;
    bool isRight = false;
    private float timer;
    private float minutes;
    private float seconds;
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
        if(!GameManager.isDead)
        {
            PLayerRepo.time += Time.deltaTime;
            minutes = Mathf.FloorToInt(PLayerRepo.time / 60.0f);
            seconds = Mathf.FloorToInt(PLayerRepo.time - minutes * 60f);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timer2Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timer3Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            MyInput();
        }
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
    public void Pause()
    {
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
        gameplayHUD.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameplayHUD.SetActive(true);
        pausedPanel.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        PLayerRepo.time = 0f;
        CustomSceneManager.instance.GoBack(0f);
    }
    public void SimpleRestart()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f);
        PLayerRepo.time = 0;
        Time.timeScale = 1;
        deathPanel.SetActive(false);
        gameplayHUD.SetActive(true);
        pausedPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DeadManWalking()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
        gameplayHUD.SetActive(false);
    }
}
