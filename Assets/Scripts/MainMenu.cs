using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button instructionsButton;
    public Button backButton;
    public Text instructionsText;

    public GameObject speedBoost;
    public GameObject timerIncrease;
    void Start()
    {
        playButton.gameObject.SetActive(true);
        instructionsButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        speedBoost.gameObject.SetActive(false);
        timerIncrease.gameObject.SetActive(false);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void InstructionsButton()
    {
        playButton.gameObject.SetActive(false);
        instructionsButton.gameObject.SetActive(false);

        instructionsText.gameObject.SetActive(true);
        instructionsText.text = "Work is finally finished and you're excited to go home! \nHowever, traffic in this city is dreadful.\n \nRide your bike through the city's upper levels to get home before the gate to your apprtment closes. \nCollect speed boosts, and timer increases to make sure you make it home in time! \n \nSome walls are breakable if you're going fast enough!";
        backButton.gameObject.SetActive(true);
        speedBoost.gameObject.SetActive(true);
        timerIncrease.gameObject.SetActive(true);
    }
    public void BackButton()
    {
        playButton.gameObject.SetActive(true);
        instructionsButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        speedBoost.gameObject.SetActive(false);
        timerIncrease.gameObject.SetActive(false);
    }
}
