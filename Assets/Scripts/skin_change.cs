using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class skin_change : MonoBehaviour
{
    public GameObject angry;
    public Material newMaterialRef;
    // Material redMaterial = new Material(Shader.Find("Standard"));
    // redMaterial.color = Color.red;
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;
    private Material material;
    angrymode angercheck;
    void Start()
    {
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
    }

    IEnumerator ChangeSkinColor(Material input, MeshRenderer meshR)
    {
        meshR.material = newMaterialRef;
        yield return new WaitForSeconds(2.0f);
        // gameObject.meshRenderer.material = newMat;
        // input.color = Color.magenta;
        // input = newmat;
    }
}
