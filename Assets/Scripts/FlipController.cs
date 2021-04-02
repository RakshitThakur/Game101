using UnityEngine;

public class FlipController : MonoBehaviour
{
    [SerializeField] GameObject level;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject player;
    
    float x;
    bool isFlipping = false;
    // Start is called before the first frame update
    void Start()
    {
       
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
       
        if (Input.GetKeyDown(KeyCode.Space) &&  !LeanTween.isTweening(level))
        {
            LeanTween.scaleY(level, -level.transform.localScale.y, 0.5f).setEaseSpring();
            LeanTween.move(player, new Vector2(player.transform.position.x, 0f), 0.1f);
           // player.transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.y);
          


        }
        if(Input.GetKey(KeyCode.A))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
      
    }
}
