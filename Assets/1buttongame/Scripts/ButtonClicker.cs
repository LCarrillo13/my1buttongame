using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
   
    [SerializeField] private Rigidbody2D rb;    
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Collider2D playerCollider;

    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float jumpHeight2 = 7;
    

    [SerializeField] private bool grounded;
    [SerializeField] private LayerMask whatIsGrounded;
    [SerializeField] private int jumpCount = 1;


    [SerializeField] private Vector3 playerMovement;
    [SerializeField] private int playerMoveSpeed;
    [SerializeField] private float playerMinX = -11.5f;
    [SerializeField] private float PlayerMaxX = 10.5f;
    [SerializeField] private int direction = 1;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGrounded);

        if(grounded == true)
        {
            jumpCount = 1;
        }
        
        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.velocity += Vector2.up * jumpHeight;
            jumpCount--;

        }
        else if (Input.GetKeyDown("space") && grounded == false && jumpCount > 0)
        {
            rb.velocity += Vector2.up * jumpHeight2;
            jumpCount--;
        }

        if (transform.position.x > PlayerMaxX)
        {
            direction = -1;
        }
        else if (transform.position.x < playerMinX)
        {
            direction = 1;
        }
        playerMovement = Vector3.right * direction * playerMoveSpeed * Time.deltaTime;
        transform.Translate(playerMovement);



    }
}
