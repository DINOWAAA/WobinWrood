using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceExitScript : MonoBehaviour
{
    [SerializeField]GameObject text;
    bool isUsable;
    [SerializeField]Transform otherTelepoint;
    [SerializeField] Transform playerTf;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        isUsable = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            isUsable = true;
            playerTf = other.transform;//referenceForPlayersTransform
        } 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
            isUsable = false;
            playerTf = null;
        }
    }

    private void Teleport ()
    {
        if(playerTf != null && otherTelepoint != null)
        {
            playerTf.position = otherTelepoint.position;//moves player to other point.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isUsable==true)
        {
            Debug.Log("Teleported");
            Teleport();
        }  
    }
}
