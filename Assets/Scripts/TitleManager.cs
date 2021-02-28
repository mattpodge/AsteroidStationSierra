using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public GameObject creditsOverlay;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void ShowCredits()
    {
        creditsOverlay.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsOverlay.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
