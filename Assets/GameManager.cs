using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //importing SceneManagement Library
using UnityEngine;

using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public Text scoretext;
    public Text Timer;
    public static int score;
    public  int timerupdate;
    public float Timeleft = 30.0f;

    void Start()
    {
      scoretext = GetComponent<Text>();
      Timer = GetComponent<Text>();
    }

    void Update()
    {

        scoretext.text = "Score: " + score;

        Timer.text = "Timer: " + Timeleft;

        Timeleft -= Time.deltaTime;

        if (Timeleft <= 0.0f)
        {
            timeup();
        }

    }

    void timeup()
    {
        SceneManager.LoadScene(0);
    }
}




