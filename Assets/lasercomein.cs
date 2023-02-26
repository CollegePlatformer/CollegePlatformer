using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercomein : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject laser;

    laserflash comein;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("7");
    }


    void Awake()
    {
        Debug.Log("3");
        comein = laser.GetComponent<laserflash>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-26, 0, 0);
        if (comein.destroyit == true)
        {
            Destroy(gameObject);
        }
    }

}
