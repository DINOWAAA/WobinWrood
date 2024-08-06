using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSpot : MonoBehaviour
{
    [SerializeField]GameObject eText;
    bool isDonatable;
    public GameObject gM;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gM.GetComponent<GameManager>();
        eText.SetActive(false);
        isDonatable = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(true);
            isDonatable = true;
        } 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(false);
            isDonatable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Collect")&&isDonatable==true)
        {
            gameManager.EmptyWeight();
            Debug.Log("Emptied");
        }  
    }
}
