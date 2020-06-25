using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void NextScene()
    {
        //SceneManager.LoadScene("Level 2"); //En måde
        //SceneManager.LoadScene(1); //En anden måde
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //En anden måde (nuværende scene index + 1)
        print("Next Scene");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //load samme scene som man er på lige nu
        print("Try Again");
    }

    public void Quit()
    {
        SceneManager.LoadScene(0); //Main menu har index 0
        print("Quit");
    }
}
