using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public AudioSource soundPlayer;
    private bool hasPlayed = false;
    [SerializeField] GameObject player;
    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            Debug.Log("gg");
            controller.atFinish = true;
            if(!hasPlayed)
            {
                soundPlayer.Play();
                hasPlayed = true;
            }
        }
    }
}
