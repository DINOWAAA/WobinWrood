using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player speed
    private Rigidbody2D rb;
    public float backPackWeight;
    public float playerSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public GameObject playerSprite;

    public float currentBackPackWeight;
    Vector2 movement;

    private void Start()
    {
        backPackWeight = 0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Sets initial speed of player when game starts
        playerSpeed = 5f;
    }

    public void UpdateWeight(float backPackWeight)
    {
        currentBackPackWeight =+ backPackWeight;
        if(currentBackPackWeight>=3f)
        {
            walkSpeed = 3f;
        }
        if(currentBackPackWeight<=2F)
        {
            walkSpeed = 5f;
        }
    }

    public void EmptyBackPack()
    {
        currentBackPackWeight = 0f;
        walkSpeed = 5f;
    }

    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButton("Crouch"))
        {
            playerSpeed = walkSpeed - crouchSpeed;
        }
        if(Input.GetButton("Sprint"))
        {
            playerSpeed = sprintSpeed + walkSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }
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