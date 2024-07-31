using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    [SerializeField]GameObject eText;
    public GameObject gM;
    GameManager gameManager;

    private bool isCollectable;
    

    void Start() 
    {
        gameManager = gM.GetComponent<GameManager>();  
        eText.SetActive(false);
        isCollectable = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(true);
            isCollectable = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(false);
            isCollectable = false;
        }    
    }

    private void Update() 
    {
        if(Input.GetButton("Collect")&&isCollectable==true)
        {
            gameManager.CollectedObject(1);
            Debug.Log("Collected");
            Destroy(gameObject);
        }    
    }
}
