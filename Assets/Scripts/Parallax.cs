using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cameraMain;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float temp = (cameraMain.transform.position.x * (1 - parallaxEffect));
        float dist = (cameraMain.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + length) startPos += length;
        else if (temp <= startPos - length) startPos -= length;
    }
}