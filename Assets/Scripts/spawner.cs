using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private bool topbound = false;
    public bool isSpawned = false;
    public float speed = 5.0f;
    private float yDownRange = 48f;
    private float yUpRange = 58f;

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

        if (transform.position.y < yDownRange)
        {
            topbound = false;
        }
        if (transform.position.y > yUpRange)
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
        //original values was between 10-15 seconds
        //original values was between 15-25 seconds
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        if (isSpawned == false)
        {
            isSpawned = true;
            Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Hello");
    }
}
