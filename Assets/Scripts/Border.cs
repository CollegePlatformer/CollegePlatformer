using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public GameObject player;
    private float timer = 3.0f;
    private bool move = false;
    public float speed = 6.0f;
    public AudioSource soundPlayer;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        player = GameObject.Find("Student");
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (player != null)
        {
            if (player.transform.position.x < gameObject.transform.position.x - 5)
            {
                gameObject.transform.position = player.transform.position - new Vector3(37, 0, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            Debug.Log("Hit");
            StartCoroutine(Hit());
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timer);
        if (!hasPlayed)
        {
            soundPlayer.Play();
            hasPlayed = true;
        }
        move = true;
    }

    IEnumerator Hit()
    {
        move = false;
        gameObject.transform.position = gameObject.transform.position - new Vector3(25, 0, 0);
        yield return new WaitForSeconds(timer - 1);
        move = true;
    }
}
