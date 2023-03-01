using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercomein : MonoBehaviour
{
    public GameObject player;

    // public bool record = false;
    public GameObject spawnercheck;
    [SerializeField] GameObject laser;

    float laserYPosition;
    spawner spawnerscript;

    laserflash comein;
    // Start is called before the first frame update
    
    void Start()
    {
        player = GameObject.Find("Templayer");
        spawnercheck = GameObject.Find("Spawner");
        spawnerscript = spawnercheck.GetComponent<spawner>();
    }


    void Awake()
    {
        comein = laser.GetComponent<laserflash>();
    }
    // Update is called once per frame
    void Update()
    {
        // originally it was -26, 0, 0
        laserYPosition = spawnercheck.transform.position.y;
        transform.position = player.transform.position + new Vector3(-26, laserYPosition, 0);
        if (comein.destroyit == true)
        {
            Destroy(gameObject);
            spawnerscript.isSpawned = false;
        }
    }

}
