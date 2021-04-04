using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, 0f, player.position.z - 10f), 0.008f);
        
    }
}
