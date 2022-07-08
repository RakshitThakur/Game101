using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    bool hasKey;
    [SerializeField] GameObject Key;
    [SerializeField] Slider playerHealthBar;
    [SerializeField] Text counter;
    float timer = 0.0f;
    int minutes, seconds;
    public float enemyHealth = 100f;
    // Start is called before the first frame update

    private void Awake()
    {   
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        hasKey = false;
        Key.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //minutes = Mathf.FloorToInt(timer / 60.0f);
        //seconds = Mathf.FloorToInt(timer - minutes * 60f);
        //counter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void GotKey()
    {
        hasKey = true;

        Key.GetComponent<SpriteRenderer>().enabled = true;   
    }
    public void CompleteLevel()
    {
        if(hasKey == true)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            y++;
            Physics2D.gravity = new Vector2(0f, -9.81f);
            if(y != -1)
            {
                SceneManager.LoadScene(y);
            }
            
        }
        else
        {
            Debug.Log("Get The Key");
        }
    }
    public void RestartLevel()
    {
        //Debug.Log("Restarted");
        Physics2D.gravity = new Vector2(0f,-9.81f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DisplayHealth(int health)
    {
        playerHealthBar.value = health;
    }
    public void GetHit()
    {
        enemyHealth -= 20;
        Debug.Log(enemyHealth);
       
    }
}
