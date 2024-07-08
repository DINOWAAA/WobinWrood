using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player speed Cont
    public int playerSpeed;

    //Player animator
    //public Animator pAnimator



    private void Start() 
    {
        //Sets initial Speed of player when game starts
        playerSpeed = 5;
    }

    void Update()
    {
    Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = playerSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -playerSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = playerSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -playerSpeed;
        }
        direction = Vector3.ClampMagnitude(direction, playerSpeed);
        transform.position += direction * Time.deltaTime;
    }
}
