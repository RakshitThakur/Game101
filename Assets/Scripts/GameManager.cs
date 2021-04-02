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
            Debug.Log("Completed");
           // SceneManager.LoadScene(2);
        }
        else
        {

        }
    }
}
