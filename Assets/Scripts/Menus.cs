using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
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
