using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Rigidbody rbPlayer;
    public bool jumpp = false;
    public int force; //mass = 0.75, force = 4
    public GameManager gm;    

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        DisableRBody();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gm.playingLevel)
        {
            DisableRBody();
        }
        else { 
            EnableRBody(); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.LogError(" jumping ");
            rbPlayer.AddForce(transform.up * force, ForceMode.Impulse);
        }
    }

    public void EnableRBody()
    {
        rbPlayer.isKinematic = false;
        rbPlayer.detectCollisions = true;
    }
    public void DisableRBody()
    {
        rbPlayer.isKinematic = true;
        rbPlayer.detectCollisions = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Debug.LogError(" LOSE ");
            Death();
        }
    }

    void Death()
    {
        gm.playingLevel = false;
        gm.Lose();
    }
}
