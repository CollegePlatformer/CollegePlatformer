using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformrespawn : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> platformholder1;
    public List<GameObject> platformholder2;
    public List<GameObject> platformholder3;
    public List<GameObject> platformholder4;
    checkpoint check;
    health invinciblechecker;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        check = player.GetComponent<checkpoint>();
        invinciblechecker = player.GetComponent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invinciblechecker.invincible == true)
        {
            Debug.Log("Im invincible");
            Instantiate(platformholder1[0], platformholder1[0].transform.position, platformholder1[0].transform.rotation);
        }
    }
}
