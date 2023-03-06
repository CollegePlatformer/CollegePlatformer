using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victorydisplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController controller;
    public Text textdisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.atFinish == true)
        {
            textdisplay.text = "You woke up and passed your exam. Poggers.";
            textdisplay.enabled = true;
            Destroy(player);
        }
        if (controller.isDead == true)
        {
            textdisplay.text = "You failed since you woke up late. unpoggers.";
            textdisplay.enabled = true;
            Destroy(player);
        }
    }
}
