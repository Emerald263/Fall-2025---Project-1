using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement Library
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    //UI variables
    public Text Scoretext;
    public Text Timer;


    public static int score;
    public float Timeleft = 60.0f;


    void Start()
    {
      Scoretext = GetComponent<Text>();
      Timer = GetComponent<Text>();

        score = 0;
    }

    void Update()
    {

        if (Timeleft <= 0.0f)
        {
            Timeleft -= Time.deltaTime;

            Debug.Log("time");
        }

        if (Timeleft == 0.0f)
        {
            timeup();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Coin")&& (collision.gameObject.tag.Equals("Player")))
        {
            score++;
            Debug.Log("collect-gm");

        }

    }

        void timeup()
    {
        SceneManager.LoadScene(0);
    }

}





