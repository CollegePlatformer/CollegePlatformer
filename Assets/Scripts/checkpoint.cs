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
    public AudioSource soundPlayer;
    public bool hasPlayed = false;
    public int checkpointnum = 0;
    void Start()
    {
        for (int i = 0; i < checkArray.Length; i++)
        {
            checkArray[i] = GameObject.Find("Checkpoint" + i);
            if (checkArray[i] != null)
            {
                touchArray[i] = false;
                positions[i] = checkArray[i].transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Checkpoint0":
                checkpointmarker = positions[0];
                checkpointnum = 1;
                Audioplay();
                break;
            case "Checkpoint1":
                checkpointmarker = positions[1];
                checkpointnum = 2;
                Audioplay();
                break;
            case "Checkpoint2":
                checkpointmarker = positions[2];
                checkpointnum = 3;
                Audioplay();
                break;
        }
    }

    void Audioplay()
    {
        if (!hasPlayed)
        {
            soundPlayer.Play();
            hasPlayed = true;
        }
        hasPlayed = false;
    }
}
