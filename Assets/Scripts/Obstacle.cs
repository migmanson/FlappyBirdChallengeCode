using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gm.playingLevel)
        {
            transform.Translate(-Vector3.right * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WorldEdge")
        {
            //Debug.LogError(" resetting " + other.transform.position + other.transform.localPosition);
            gameObject.transform.Translate(new Vector3(25, 0, 0));
        }
    }

}
