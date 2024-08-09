using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaughtLogic : MonoBehaviour
{
    [SerializeField] Transform KickSpot;
    [SerializeField] Transform playerT;
    GameManager gM;
    [SerializeField] GameObject gameManager;

    private void Start() 
    {
        gM = gameManager.GetComponent<GameManager>();    
    }
    public void Caught()
    {
        gM.EmptyWeight();
        playerT.position = KickSpot.position;
    }
}