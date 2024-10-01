using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public float timeRemaining = 60.0f;
    public Text speedText;

    public GameObject door;
    public Text gameOverText;
    public Button restartButton;

    public PlayerController playerController;

    // This will change the colour of the speed text in the UI
    private Color startSpeedColour;
    private Color pinkSpeedColour;
    private Color yellowSpeedColour;
    private Color blueSpeedColour;
    private Color purpleSpeedColour;

    public string startSpeedHex = "#72FF00";
    public string pinkSpeedHex = "#FEB2B2";
    public string yellowSpeedHex = "#FDFEBC";
    public string blueSpeedHex = "#39B2C3";
    public string purpleSpeedHex = "#9B34FC";

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);      // this sets the door in the scene to not be active, that way the level is finishable but we can active the door later if we need to
        playerController = FindObjectOfType<PlayerController>();

        restartButton.gameObject.SetActive(false);

        // This is to convert the Hex to colour
        ColorUtility.TryParseHtmlString(startSpeedHex, out startSpeedColour);
        ColorUtility.TryParseHtmlString(pinkSpeedHex, out pinkSpeedColour);
        ColorUtility.TryParseHtmlString(yellowSpeedHex, out yellowSpeedColour);
        ColorUtility.TryParseHtmlString(blueSpeedHex, out blueSpeedColour);
        ColorUtility.TryParseHtmlString(purpleSpeedHex, out purpleSpeedColour);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)      // if there is more than 0 on the clock
        {
            timeRemaining -= Time.deltaTime;    // reduce the time by 1 second
            UpdateTimer();
        }
        else if (timeRemaining <= 0)
        {                                   // this sets the timer text to 00:00
            timerText.text = "00:00";       // This is to avoid the timer reading a negative number
            CloseDoor();
        }

        UpdateSpeed();
    }

    public void AddTime(float timeAdded)    // this is called via the PowerUps.cs
    {
        timeRemaining += timeAdded;         // it adds the amount of time defined in that script to the current timer
        UpdateTimer();
    }
    void UpdateTimer()          // this converts the timer into a nice readable timer eg 01:30
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds + " TIMER");
    }
    void CloseDoor()
    {
        door.SetActive(true);   // when the timer hits 0 this will make the "door" active in the scene
    }

    public void GameOver()      // called via the PlayerController.cs
    {
        gameOverText.text = "Game Over! You didnt make it home in time, too bad! guess youre on sleeping outside tonight...";
        restartButton.gameObject.SetActive(true);       // makes text and a button appear on screen
    }
    public void RestartButton()       // This is how the restart button resets the scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void UpdateSpeed()         // this is the code that tells the speed text what colour it should be
    {                           // changes depending on the speed of the player
        float moveSpeed = playerController.moveSpeed;
        speedText.text = moveSpeed.ToString() + " M / S";

        if (moveSpeed < 15)
        {
            speedText.color = startSpeedColour;
        }
        else if (moveSpeed < 20)
        {
            speedText.color = pinkSpeedColour;
        }
        else if (moveSpeed < 25)
        {
            speedText.color = yellowSpeedColour;
        }
        else if (moveSpeed < 30)
        {
            speedText.color = blueSpeedColour;
        }
        else
        {
            speedText.color = purpleSpeedColour;
        }
    }
}
