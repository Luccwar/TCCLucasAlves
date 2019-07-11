using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    private PlayerExperience playerExp;

    //Integers
    public int curHealth;
    public int maxHealth = 100;
    public int experienceToAdd;
 
    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    //Booleans
    public bool awake = false;
    public bool lookingRight = false;
    public bool lookingLeft = true;

    //References
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

        playerExp = FindObjectOfType<PlayerExperience>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);
        anim.SetBool("LookingLeft", lookingLeft);

        RangeCheck();


        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = false;
            lookingLeft = true;
        }
        else if (target.transform.position.x < transform.position.x)
        {
            lookingLeft = false;
            lookingRight = true;
        }

        if (curHealth <= 0)
        {
            Destroy(gameObject);

            playerExp.AddExperience(experienceToAdd);
        }

    }


    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
        }

        if(distance > wakeRange)
        {
            awake = false;
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }

        }
    }

    void TakeDamage(int damage)
    {
        curHealth -= damage;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Sword") || col.gameObject.CompareTag("PlayerProjectile"))
        {
            TakeDamage(20);
        }
    }

    }
