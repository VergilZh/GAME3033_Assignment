using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public float enemyHealth = 100;
    public Animator zombieAnim;
    public Transform spawnitem;

    public GameObject ironBar;
    public GameObject copperBar;
    //public NavMeshAgent zombieNav;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();
        zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyFollowTarget();
        if (enemyHealth <= 0)
        {
            EnemyDied();
        }

        //zombieNav.SetDestination(target.position);
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
        FindObjectOfType<PlayerBehaviour>().playerScore += 10;
        RandomItem();
    }

    public void RandomItem()
    {
        int ItemsNum = Random.Range(0, 100);

        if(ItemsNum <= 50)
        {

        }
        if (ItemsNum >= 50 && ItemsNum <= 80)
        { 
            Instantiate(ironBar, spawnitem.position, spawnitem.rotation);
        }
        if (ItemsNum >= 80 && ItemsNum <= 100)
        {
            Instantiate(copperBar, spawnitem.position, spawnitem.rotation);
        }

        print(ItemsNum);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerBehaviour>().PlayerDamage(10);
            zombieAnim.SetInteger("action", 1);
            speed = 0;
        }
    }
    
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            zombieAnim.SetInteger("action", 0);
            speed = 1;
        }
    }
}
