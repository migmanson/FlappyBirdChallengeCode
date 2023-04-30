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

	void Start()
    {
        playingLevel = false;
		paused = false;
    }

    public void StartLevel()
    {
		//Debug.LogError(" start game ");
		StartCoroutine("StartTheLevel");
    }

    IEnumerator StartTheLevel()
    {		
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
				//Debug.LogError("time scale 0 ");
			}
			else
			{
				// unpause Unity
				Time.timeScale = 1f;
				//Debug.LogError("time scale 1 ");
			}
		}
	}

	public void Lose()
	{
		uicontroller.LoseMenu();
	}
}
