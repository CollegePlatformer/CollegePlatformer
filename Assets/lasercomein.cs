using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercomein : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-37, 3, 0);
    }

}
