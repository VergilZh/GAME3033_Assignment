using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public float enemyHealth = 100;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyFollowTarget();
        if (enemyHealth <= 0)
        {
            EnemyDied();
        }
    }

    void EnemyFollowTarget()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(position);
        transform.LookAt(target);
    }

    public void EnemyDamage(float damage)
    {
        enemyHealth -= damage;
    }

    public void EnemyDied()
    {
        Destroy(gameObject);
        Debug.Log("hit");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerBehaviour>().PlayerDamage(10);
        }
    }
}
