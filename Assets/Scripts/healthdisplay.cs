using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthdisplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    health healthchecker;
    public Image[] hearts;
    private int heartlives = 3;
    // Start is called before the first frame update
    void Awake()
    {
        healthchecker = player.GetComponent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heartlives != healthchecker.lives)
        {
            hearts[heartlives - 1].enabled = false;
            heartlives--;
        }
    }
}
