using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playagain : MonoBehaviour
{
    public void PlayGame ()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Debug.Log("pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Level1");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            Debug.Log("Pressed");
            Physics.gravity = new Vector3(0, -9.8f, 0);
            SceneManager.LoadScene("Level1");
        }
    }
}
 