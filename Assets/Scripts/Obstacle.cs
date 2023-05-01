using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gm;
    public UIController uicontroller;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        uicontroller = gm.GetComponentInParent<UIController>();
    }
    void Update()
    {
        if (gm.playingLevel)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * 5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {           
            gm.player_score++;
            uicontroller.UpdateScore();
            Debug.LogError("score>> " + gm.player_score);
        }
        else if (other.tag == "WorldEdge")
        {
            //Debug.LogError(" resetting " + other.transform.position + other.transform.localPosition);
            gameObject.transform.Translate(new Vector3(30, 0, 0));
        }
    }

}
