using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool isDead = false;
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
        isDead = false;
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
                if(PLayerRepo.CurrentGameMode == GameMode.Online)
                    AuthManager.instance.UpdateLeaderBoardEntry((int)PLayerRepo.time);
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
        GameManager.isDead = true;
        //Debug.Log("Restarted");
        Physics2D.gravity = new Vector2(0f,-9.81f);
        if(PLayerRepo.QuickRestart)
        {
            PLayerRepo.time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            FindObjectOfType<PlayerController>().DeadManWalking();
        }
    }
    
    public void DisplayHealth(int health)
    {
        //playerHealthBar.value = health;
    }
    public void GetHit()
    {
        enemyHealth -= 20;
        Debug.Log(enemyHealth);
       
    }
}
