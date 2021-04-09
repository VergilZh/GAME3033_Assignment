using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public ParticleSystem blood;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 rotation = transform.rotation.eulerAngles;

        //transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag == "Enemy")
        {
            Instantiate(blood, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            other.GetComponent<EnemyBehaviour>().EnemyDamage(50);
        }
        if (other.tag == "EditorOnly")
        { 
        
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
