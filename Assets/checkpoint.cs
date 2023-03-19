using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject[] checkArray = new GameObject[3];
    public bool[] touchArray = new bool[3]; 
    public Vector3[] positions = new Vector3[3];
    // Start is called before the first frame update
    public Vector3 checkpointmarker;
    private string platformtouch;
    void Start()
    {
        for (int i = 0; i < checkArray.Length; i++)
        {
            checkArray[i] = GameObject.Find("Checkpoint" + i);
            touchArray[i] = false;
            positions[i] = checkArray[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.name)
        {
            case "Checkpoint0":
                Debug.Log("its lit");
                checkpointmarker = positions[0];
                Debug.Log(checkpointmarker);
                break;
            case "Checkpoint1":
                Debug.Log("Two baby");
                checkpointmarker = positions[1];
                Debug.Log(checkpointmarker);
                break;
            case "Checkpoint2":
                Debug.Log("Three's company too");
                checkpointmarker = positions[2];
                Debug.Log(checkpointmarker);
                break;
        }
    }
}
