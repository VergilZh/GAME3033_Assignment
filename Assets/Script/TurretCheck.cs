using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCheck : MonoBehaviour
{
    public TurretBehaviour TB;
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
        if (other.tag == "Enemy")
        {
            TB.target = other.GetComponent<Transform>();
        }
    }
}
