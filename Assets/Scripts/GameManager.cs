using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public float timeRemaining = 150.0f;

    public GameObject doorPreFab;
    public Transform doorSpawn;

    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimer();
        }  
        else if(timeRemaining <= 0)
        {
            timerText.text = "00:00";
            CloseDoor();
        }  
    }

    public void AddTime(float timeAdded)
    {
        timeRemaining += timeAdded;
        UpdateTimer();
    }
    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void CloseDoor()
    {
        if(doorPreFab != null && doorSpawn != null)
        {
            GameObject door = Instantiate(doorPreFab, doorSpawn.position, doorSpawn.rotation);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! You didnt make it home in time, too bad! guess youre on sleeping outside tonight...";
    }
}
