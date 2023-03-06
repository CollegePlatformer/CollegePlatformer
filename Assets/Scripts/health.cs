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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // healthtext.text = lives.ToString();
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
        invincible = true;
        lives--;
        yield return new WaitForSeconds(itimer);
        invincible = false;
    }
}