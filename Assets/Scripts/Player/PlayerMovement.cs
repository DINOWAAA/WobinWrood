using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player speed
    private Rigidbody2D rb;
    public float playerSpeed;
    public GameObject playerSprite;

    Vector2 movement;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Sets initial speed of player when game starts
        playerSpeed = 5f;
    }

    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        if (movement.x < 0)
        {
            playerSprite.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            playerSprite.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }    
}