using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playingLevel;
    public bool paused;
    public Rigidbody rbPlayer;
    public UIController uicontroller;
    public PlayerBehaviour player;
    public int player_score;
    public int player_highscore;

    void Start()
    {
        playingLevel = false;
        paused = false;
    }

    public void StartLevel()
    {
        ProcessHighScore();
        //Debug.LogError(" start game ");
        StartCoroutine("StartTheLevel");
    }

    IEnumerator StartTheLevel()
    {
        player_score = 0;
        uicontroller.StartGame();
        yield return new WaitForSeconds(2);

        playingLevel = true;

        player.EnableRBody();
        rbPlayer.AddForce(transform.up * 4.0f, ForceMode.Impulse);

        // player start animation
    }

    public bool Paused
    {
        get
        {
            // get paused
            return paused;
        }
        set
        {
            // set paused
            paused = value;
            if (paused)
            {
                // pause time
                Time.timeScale = 0f;
            }
            else
            {
                // unpause Unity
                Time.timeScale = 1f;
            }
        }
    }

    public void Lose()
    {
        ProcessHighScore();
        uicontroller.LoseMenu();
    }

    public void ProcessHighScore()
    {
        // grab high score from prefs
        if (PlayerPrefs.HasKey("_highScore"))
        {
            player_highscore = PlayerPrefs.GetInt("_highScore");
        }

        if (player_highscore < player_score)
        {
            PlayerPrefs.SetInt("_highScore", player_score);
        }
    }
}
