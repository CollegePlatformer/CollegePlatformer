using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundborder : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
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
            player.transform.position = player.transform.position + new Vector3(0, 15, 0);
        }
    }
}
