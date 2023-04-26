using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angrymode : MonoBehaviour
{
    public GameObject border;
    Border bordergameobject;
    private bool fast = false;
    public bool angry = false;
    private bool hasPlayed = false;
    private float speedduration = 3.0f;
    private float speedincrease = 2.0f;
    public AudioSource angrySound;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.Find("Pusher");
        bordergameobject = border.GetComponent<Border>();
    }

    // Update is called once per frame
    void Update()
    {
        if (angry == true)
        {
            StartCoroutine(imPissed());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            angry = true;
            if (hasPlayed == false)
            {
                angrySound.Play();
                hasPlayed = true;
            }
        }
    }

    IEnumerator imPissed()
    {
        if (fast == false)
        {
            fast = true;
            Debug.Log("AngryTime");
            bordergameobject.speed += speedincrease;
            yield return new WaitForSeconds(speedduration);
            bordergameobject.speed -= speedincrease;
            // fast = false;
        }
    }
}
