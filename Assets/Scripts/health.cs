using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int lives = 3;
    public bool invincible = false;
    //itimer = invincibility timer
    public float itimer = 3f;
    [SerializeField] GameObject player;
    PlayerController controller;
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
        // healthtext.text = lives.ToString();
        if (lives == 0)
        {
            controller.isDead = true;
        }
        //Debug.Log("Invincibility is now" + invincible);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && invincible == false)
        {
            StartCoroutine(Hit());
        }
    }

    public IEnumerator Hit()
    {
        Debug.Log("I have been Hit");
        invincible = true;
        lives--;
        if(!hasPlayed)
        {
            soundPlayer.Play();
            hasPlayed = true;
        }
        yield return new WaitForSeconds(itimer);
        invincible = false;
        hasPlayed = false;
    }
}