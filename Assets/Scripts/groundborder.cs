using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundborder : MonoBehaviour
{
    public GameObject player;
    checkpoint check;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        check = player.GetComponent<checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            Debug.Log("Hit");
            // player.transform.position = player.transform.position + new Vector3(0, 15, 0);
            player.transform.position = check.checkpointmarker + new Vector3(0, 5, 0);
        }
    }
}
