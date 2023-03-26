using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victorydisplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController controller;
    public Text textdisplay;
    public Image img;
    public GameObject[] buttons;
    public AudioSource soundPlayer;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.atFinish == true)
        {
            textdisplay.text = "You woke up and passed your exam. Poggers.";
            textdisplay.enabled = true;
            img.enabled = true;
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
            Destroy(player);
        }
        if (controller.isDead == true)
        {
            if(!hasPlayed)
            {
                soundPlayer.Play();
                hasPlayed = true;
            }
            textdisplay.text = "You failed since you woke up late. Unpoggers.";
            textdisplay.enabled = true;
            img.enabled = true;
            buttons[0].SetActive(true);
            Destroy(player);
        }
    }
}
