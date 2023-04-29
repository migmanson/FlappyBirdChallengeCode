using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playingLevel)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
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
