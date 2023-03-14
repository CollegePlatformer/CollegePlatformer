using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerShot")
        {
            enemyHealth--;
            Destroy(other.gameObject);
        }

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
