using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    private float timer = 0f;

    public Text nameText;

    public GameObject StartingScene;
    public GameObject StartScreenCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < Mathf.Epsilon)
        {
            nameText.CrossFadeAlpha(0f, 3f, false);
        }
        
        timer += Time.deltaTime;

        if(timer > 3f)
        {
            StartingScene.SetActive(false);
            StartScreenCanvas.SetActive(true);
        }

    }

    private void ChangeColor()
    {
        nameText.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }
    
}
