using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashready : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController dash;
    public Image[] dashstatus;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        dash = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dash.dashReady)
        {
            dashstatus[0].enabled = true;
            dashstatus[1].enabled = false;
        }
        else
        {
            dashstatus[0].enabled = false;
            dashstatus[1].enabled = true;
        }
    }
}
