using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollision : MonoBehaviour
{
    public GameObject gM;
    GameManager gameManager;

    private void Start() 
    {
        gameManager = gM.GetComponent<GameManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectedObject(1);
            Debug.Log("Collected");
            Destroy(gameObject);
        }    
    }
}