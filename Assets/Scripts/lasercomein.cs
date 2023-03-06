using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercomein : MonoBehaviour
{
    public GameObject player;

    // public bool record = false;
    public GameObject spawnercheck;
    [SerializeField] GameObject laser;

    // float laserYPosition;
    spawner spawnerscript;

    Vector3 newPosition;

    laserflash comein;
    // Start is called before the first frame update
    
    void Start()
    {
        player = GameObject.Find("Player");
        spawnercheck = GameObject.Find("Spawner");
        spawnerscript = spawnercheck.GetComponent<spawner>();
        // laserYPosition = Random.Range(-2.0f, 2.0f);
    }


    void Awake()
    {
        comein = laser.GetComponent<laserflash>();
    }
    // Update is called once per frame
    void Update()
    {
        newPosition = gameObject.transform.position;
        newPosition.x = player.transform.position.x - 26f;
        newPosition.y = gameObject.transform.position.y;
        gameObject.transform.position = newPosition;

        if (comein.destroyit == true)
        {
            Destroy(gameObject);
            spawnerscript.isSpawned = false;
        }
    }

}
