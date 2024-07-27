using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public GameObject tutorialCanvas;
    [SerializeField] GameObject gameEndCanvas;
    public TextMeshProUGUI weightNumber;
    int collectedAmount;
    public TextMeshProUGUI currentTimer;

    float remainingTimer;
    public float startTimerAmount;

    public bool gameRunning;
    bool roundOver = false;

    void Awake ()
    {
        gameRunning = false;
        Time.timeScale = 0f;
        gameEndCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        remainingTimer = startTimerAmount;
        //testinggamestart
        //gameRunning = true;
        collectedAmount = 0;
    }
    public void CollectedObject(int score)
    {
        collectedAmount += score;
    }


    public void GameStart()
    {
        gameRunning = true;
        tutorialCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    void GameEnd()
    {
        print("timer Finished");
        Time.timeScale = 0f;
        gameEndCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning == true)
        {
            remainingTimer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTimer/60);
            int seconds = Mathf.FloorToInt(remainingTimer%60);
            currentTimer.text = string.Format("{0:00}:{1:00}",minutes, seconds);

            weightNumber.text = collectedAmount.ToString();
        }
        if (remainingTimer < 0f)
            {
                gameRunning = false;
                roundOver = true;
                remainingTimer = 0f;
            }
        if (gameRunning == false && roundOver == true)
        {
            GameEnd();
        }
    }
}
