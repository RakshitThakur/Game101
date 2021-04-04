using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpsideDown();
    }
    void UpsideDown()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !LeanTween.isTweening(mainCamera))
        {
            LeanTween.rotateAround(mainCamera, Vector3.forward, 180f, 0.5f).setEaseSpring();
            Physics2D.gravity = -Physics2D.gravity;
        }
    }
}
