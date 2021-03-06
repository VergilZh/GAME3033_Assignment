using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxBehaviour : MonoBehaviour
{
    public int AmmoNumber;
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
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<PlayerBehaviour>().totalAmmo += AmmoNumber;
            FindObjectOfType<PlayerBehaviour>().pickUp.Play();
        }
    }
}
