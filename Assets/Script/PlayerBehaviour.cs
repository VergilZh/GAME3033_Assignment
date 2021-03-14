using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;
    public GameObject bulletPrefab;
    public GameObject turretPrefab;
    public Transform bulletSpawn;
    public Transform turretSpawn;
    public GameObject playerBag;
    public Slider healthBar;

    public float MaxHealth = 100;
    public float speed = 12f;
    public float gravity = -9.8f;
    public bool isBagOpen;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = MaxHealth;
        playerBag.SetActive(false);
        isBagOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            OpenFire();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetTurret();
            Debug.Log("set");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isBagOpen == false)
            {
                playerBag.SetActive(true);
                isBagOpen = true;
            }
            else
            {
                playerBag.SetActive(false);
                isBagOpen = false;
            }
        }
    }

    public void PlayerDamage(int damage)
    {
        MaxHealth -= damage;
        healthBar.value = MaxHealth;
    }

    void OpenFire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Debug.Log("fire");
    }

    void SetTurret()
    {
        //Instantiate(turretPrefab, turretSpawn);
        GameObject turret = Instantiate(turretPrefab);
        turret.transform.position = turretSpawn.position;
    }


}
