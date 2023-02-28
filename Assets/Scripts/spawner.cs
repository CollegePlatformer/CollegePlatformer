using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private bool topbound = false;
    public bool isSpawned = false;
    public float speed = 5.0f;
    private float yRange = 4f;

    public GameObject laserPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, yposition, transform.position.z);
        // yposition++;
        if (topbound == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        } 
        if (topbound == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (transform.position.y < -yRange)
        {
            topbound = false;
        }
        if (transform.position.y > yRange)
        {
            topbound = true;
        }
        if (!isSpawned)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        //original values was between 15-25 seconds
        yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
        if (isSpawned == false)
        {
            isSpawned = true;
            Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Hello");
    }
}
