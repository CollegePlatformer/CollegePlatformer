using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Blink : MonoBehaviour
{
    GameObject[] children = new GameObject[3];
    SkinnedMeshRenderer[] childMeshRenderers = new SkinnedMeshRenderer[3];
    Color[,] childColors = new Color[3, 2];
    health healthcomponents;
    private float blinkfrequency = 0.2f;
    private bool blink = false;

    // Some of the skinnedmeshrenderers have two materials in each gameobjects;
    Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        healthcomponents = this.gameObject.GetComponent<health>();
        // for (int i = 0; i < 3; i++)
        // {
        //     children[i] = transform.GetChild(i).gameObject;
        // }
        // for (int i = 0; i < 3; i++)
        // {
        //     childMeshRenderers[i] = children[i].GetComponent<SkinnedMeshRenderer>();
        // }
        // for (int i = 0; i < 3; i++)
        // {
        //     childColors[i, 0] = childMeshRenderers[i].materials[0].color;
        //     Debug.Log(childColors[i, 0]);
        //     if (i == 1 || i == 2)
        //     {
        //         childColors[i, 1] = childMeshRenderers[i].materials[1].color;
        //         Debug.Log(childColors[i, 1]);
        //     }
        // }

        for (int i = 0; i < 3; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
            childMeshRenderers[i] = children[i].GetComponent<SkinnedMeshRenderer>();
            childColors[i, 0] = childMeshRenderers[i].materials[0].color;
            if (i == 1 || i == 2)
            {
                childColors[i, 1] = childMeshRenderers[i].materials[1].color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthcomponents.invincible == true && blink == false)
        {
            blink = true;
            StartCoroutine(flash());
        }
    }

    IEnumerator flash()
    {
        while (healthcomponents.invincible == true)
        {
            changeToRed();
            yield return new WaitForSeconds(blinkfrequency);
            changeToOriginal();
            yield return new WaitForSeconds(blinkfrequency);
        }
        blink = false;
    }

    void changeToRed()
    {
        for (int i = 0; i < 3; i++)
        {
            childMeshRenderers[i].material.color = Color.red;
            if (i == 1 || i == 2)
            {
                childMeshRenderers[i].materials[1].color = Color.red;
            }
        }
    }

    void changeToOriginal()
    {
        for (int i = 0; i < 3; i++)
        {
            childMeshRenderers[i].material.color = childColors[i, 0];
            if (i == 1 || i == 2)
            {
                childMeshRenderers[i].materials[1].color = childColors[i, 1];
            }
        }
    }
}
