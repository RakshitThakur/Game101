using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasKey;
    [SerializeField] GameObject Key;
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        Key.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
