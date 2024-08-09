using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Collider2D enemyScanZone;
    private Vector3 targetPosition;
    [SerializeField] float enemySpeed = 3f;
    private bool facingRight = true;

    [SerializeField] GameObject gameManager;
    PlayerCaughtLogic pCaught;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = pointA.position;
        pCaught = gameManager.GetComponent<PlayerCaughtLogic>();
    }

    void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed *Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            pCaught.Caught();
            SelfDestruct();
        }    
    }

    void SelfDestruct()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
}
