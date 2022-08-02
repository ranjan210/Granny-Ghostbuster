using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movement : MonoBehaviour
{

    public AudioClip melee;
    public AudioClip shoot;
    public AudioClip walkSound;
    public AudioSource audioSrc;

    public float speed;
    bool inAir = false;
    AudioSource audioSource;
    GameObject barrel;
    public GameObject bulletPrefab;

    public int jumpHeight;

    Rigidbody2D rb;

    Animator animator;

    public Transform attackPoint;
    public Transform cameraPoint;
    public float cameraLengthLimit;
    public float attackRange = 0.5f;
    public float attackSpeed = 2f;
    public float shootSpeed;
    bool rightPress = false;
    bool leftPress = false;
    bool jumpPress = false;
    bool shotsFired = false;
    bool blocking = false;

    float nextAttackTime;
    float nextShootTime;
    public LayerMask enemyLayers;

    public int melDamage;

    int health = 100;
    public float pushForce;
    sliderChange sliderChange;
    public UnityAndroidVibrator vibrator;
    public GameObject healthBar;
    public GameObject shield;
    GameManager manager;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        barrel = GameObject.FindGameObjectWithTag("barrel");
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        animator.SetFloat("moveSpeed", 0.0f);
        sliderChange = healthBar.GetComponent<sliderChange>();
        sliderChange.setHealthMax(health);
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        float xInput = 0;
        if (rightPress && leftPress)
        {
            xInput = 0;
        }
        else if (rightPress)
        {
            xInput = 1;
        }
        else if (leftPress)
        {
            if (Vector2.Distance(transform.position, cameraPoint.position) > cameraLengthLimit)
            {
                xInput = -1;
            }
        }
        else
        {
            xInput = 0;
        }

        Debug.Log(xInput);

        if (xInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetFloat("moveSpeed", -xInput);
        }
        else if (xInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("moveSpeed", xInput);
        }
        else
        {
            animator.SetFloat("moveSpeed", 0.0f);
        }



        transform.Translate(Vector2.right * xInput * speed, Space.World);

        if (jumpPress && inAir)
        {
            jumpPress = false;
        }

        if ((Input.GetButtonDown("Jump") || jumpPress) && !inAir)
        {
            animator.SetTrigger("isJump");
            animator.SetBool("isIdle", false);
            rb.AddForce(Vector2.up * jumpHeight);
            inAir = true;
            jumpPress = false;
        }

        if (shotsFired && !blocking)
        {
            if (Time.time > nextShootTime)
            {
                animator.SetTrigger("isShoot");
                audioSource.PlayOneShot(shoot);
                nextShootTime = Time.time + 1 / shootSpeed;
            }

        }


    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Ground")
        {
            animator.SetBool("isIdle", true);
            inAir = false;
        }

        // If the object we hit is the enemy
        if (other.collider.gameObject.tag == "ghosts")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - (Vector2)transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * pushForce);
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, barrel.transform.position, barrel.transform.rotation);
        vibrator.VibrateForGivenDuration(75);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, (attackPoint.position - transform.position).magnitude, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(melDamage);
            Vector3 dir = transform.position - enemy.transform.position;
            dir = dir.normalized;
            enemy.GetComponent<Enemy>().PushBack(dir);

        }
    }

    /*void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(transform.position, (attackPoint.position - transform.position).magnitude);
    }*/


    public void TakeDamage(int damage)
    {
        health -= damage;
        sliderChange.setHealth(health);
        animator.SetTrigger("isHurt");
        if (health <= 0)
        {
            Die();
        }
    }



    void Die()
    {
        manager.game_Over();
        gameObject.GetComponent<movement>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }

    public void rightPressed()
    {
        rightPress = true;
        vibrator.VibrateForGivenDuration(75);

    }
    public void leftPressed()
    {
        leftPress = true;
        vibrator.VibrateForGivenDuration(75);


    }

    public void rightUnPreseed()
    {
        rightPress = false;
        Debug.Log("lolright");

    }

    public void leftUnPressed()
    {
        leftPress = false;
        Debug.Log("lolleft");

    }

    public void jumpPressed()
    {
        jumpPress = true;
        vibrator.VibrateForGivenDuration(75);
    }

    public void Fire()
    {
        shotsFired = true;
    }

    public void stopFire()
    {
        shotsFired = false;
    }

    public void Block()
    {
        blocking = true;
        shield.SetActive(true);

        vibrator.VibrateForGivenDuration(75);

    }

    public void stopBlock()
    {
        shield.SetActive(false);
        blocking = false;
    }
}
