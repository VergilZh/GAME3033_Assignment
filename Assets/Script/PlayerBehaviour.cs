using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;
    public GameObject bulletPrefab;
    public GameObject turretPrefab;
    public Transform bulletSpawn;
    public Transform turretSpawn;
    public GameObject playerBag;
    public Slider healthBar;
    public Animator gunAnim;

    [Header("Audio")]
    public AudioSource openFire;
    public AudioSource reload;
    public AudioSource pickUp;

    [Header("UI Text")]
    public Text currentAmmoText;
    public Text totalAmmoText;
    public Text ironBarText;
    public Text copperBarText;
    public Text score;
    

    [Header("Player Massage")]
    public float MaxHealth = 100;
    public float currentAmmo = 6;
    public float totalAmmo = 60;
    public float ironBar;
    public float copperBar;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float playerScore;
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

        PlayerMovement();

        currentAmmoText.text = currentAmmo.ToString();
        totalAmmoText.text = totalAmmo.ToString();
        ironBarText.text = ironBar.ToString();
        copperBarText.text = copperBar.ToString();
        score.text = playerScore.ToString();

        if (MaxHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PlayerDamage(int damage)
    {
        MaxHealth -= damage;
        healthBar.value = MaxHealth;
    }

    public IEnumerator PlayerDamageTest(int damage)
    {
        while (MaxHealth >= 0)
        {
            yield return new WaitForSeconds(2);
            MaxHealth -= damage;
        }
        healthBar.value = MaxHealth;
    }

    void OpenFire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        gunAnim.SetBool("Reload" ,false);
        openFire.Play();
    }

    void SetTurret()
    {
        //Instantiate(turretPrefab, turretSpawn);
        GameObject turret = Instantiate(turretPrefab);
        turret.transform.position = turretSpawn.position;
    }

    public void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                OpenFire();
                currentAmmo -= 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeAmmoClips();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ironBar >= 6 && copperBar >= 2)
            { 
                SetTurret();
                ironBar -= 6;
                copperBar -= 2;
            }
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

    void ChangeAmmoClips()
    {
        if (totalAmmo >= 6)
        {
            currentAmmo = 6;
            totalAmmo = totalAmmo - 6;
        }
        gunAnim.SetBool("Reload", true);
        reload.Play();
    }


}
