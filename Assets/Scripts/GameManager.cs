using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame ()
    {
        if(gameIsPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
}
