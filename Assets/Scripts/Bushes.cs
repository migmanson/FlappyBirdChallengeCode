using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gm.playingLevel)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WorldEdge")
        {
            //Debug.LogError(" resetting " + other.transform.position + other.transform.localPosition);
            gameObject.transform.Translate(new Vector3(-48, 0, 0));
        }
    }
}
