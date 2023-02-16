using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthdisplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    health healthchecker;
    public Text healthtext;
    // Start is called before the first frame update
    void Awake()
    {
        healthchecker = player.GetComponent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = "Health: " + healthchecker.lives.ToString();
    }
}
