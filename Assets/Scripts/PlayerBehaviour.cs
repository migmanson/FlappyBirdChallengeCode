using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Rigidbody rbPlayer;
    public bool jumpp = false;
    public int force; //mass = 0.75, force = 4
    public GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        DisableRBody();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
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

    void EnableRBody()
    {
        rbPlayer.isKinematic = false;
        rbPlayer.detectCollisions = true;
    }
    void DisableRBody()
    {
        rbPlayer.isKinematic = true;
        rbPlayer.detectCollisions = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Debug.LogError(" LOSE ");
            gm.playingLevel = false;
        }
    }
}
