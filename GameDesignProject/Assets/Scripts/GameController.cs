using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text uiText;

    public void Awake()
    {
        instance = this;
    }

    public int bullets = 10;

    public void SetBullets(int bullets)
    {
        this.bullets = bullets;
        uiText.text = "Bullets: " + bullets;
    }
}
