using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasertime : MonoBehaviour
{
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner");
        spawner.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            spawner.SetActive(true);
        }
    }
}
