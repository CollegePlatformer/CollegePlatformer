using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class skin_change : MonoBehaviour
{
    public GameObject angry;
    public GameObject border;
    public Material newMaterialRef;
    public Material hitMaterial;
    // Material redMaterial = new Material(Shader.Find("Standard"));
    // redMaterial.color = Color.red;
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;
    private Material material;
    private Material materialold;
    angrymode angercheck;
    Border hitcheck;
    void Start()
    {
        // border = GameObject.Find("Pusher");
        hitcheck = border.GetComponent<Border>();
        angercheck = angry.GetComponent<angrymode>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        // newMat = Material.Load("Pink", typeof(Material)) as Material;
        // meshRenderer.material = newMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (angercheck.angry == true)
        {
            StartCoroutine(ChangeSkinColor(material, meshRenderer));
        }
        // Debug.Log("Pencil hit is now " + hitcheck.pencilhit);
        if (hitcheck.pencilhit)
        {
            // Debug.Log("Pwease");
            StartCoroutine(SkinHit());
        }
    }

    IEnumerator ChangeSkinColor(Material input, MeshRenderer meshR)
    {
        materialold = input;
        meshR.material = newMaterialRef;
        yield return new WaitForSeconds(2.0f);
        // gameObject.meshRenderer.material = newMat;
        // input.color = Color.magenta;
        // input = newmat;
    }
    IEnumerator SkinHit()
    {
        // Debug.Log("Material previous was " + materialold);
        // materialold = meshRenderer.material;
        // material.color = Color.yellow;
        meshRenderer.material = hitMaterial;
        // Debug.Log("Please change to yellow");
        yield return new WaitForSeconds(1.0f);
        if (angercheck.angry)
        {
            meshRenderer.material = newMaterialRef;
        }
        else
        {
            meshRenderer.material = material;
        }
        // Debug.Log("Material now is " + materialold);
    }
}
