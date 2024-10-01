using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

}
