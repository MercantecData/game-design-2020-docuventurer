using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen;

    [SerializeField]
    private GameObject settingsScreen;

    void Start()
    {
        settingsScreen.SetActive(false);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToMainScreen()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void ToSettingsScreen()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
}
