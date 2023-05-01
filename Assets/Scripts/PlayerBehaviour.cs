using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Rigidbody rbPlayer;
    public int force; //mass = 0.75, force = 4
    public GameManager gm;
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        DisableRBody();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim.Stop();
    }

    void Update()
    {
        if (!gm.playingLevel)
        {
            DisableRBody();
        }
        else
        {
            EnableRBody();
            anim.Play();
        }

        // avoid going off screen at the top
        if (transform.localPosition.y < 0.70f)
        {
            #if UNITY_ANDROID
                if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    rbPlayer.AddForce(transform.up * force, ForceMode.Impulse);
                }            
            #else
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    //Debug.LogError(" jumping ");
                    rbPlayer.AddForce(transform.up * force, ForceMode.Impulse);
                }
            #endif
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
        anim.Stop();
    }
}
