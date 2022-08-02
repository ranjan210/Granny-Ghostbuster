using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public int enemyDamage;
    public int playerDamage;
    public float speed;
    public float thresold;
    public ParticleSystem particleSys;
    Rigidbody2D rb;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spawnPos, transform.position) > thresold)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ghosts")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemyDamage);
                ParticleSystem ps =Instantiate(particleSys,transform.position,transform.rotation);
                 ParticleSystem.MainModule psmain = ps.main;
                psmain.startColor = Color.white;

            }
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            movement movement = col.gameObject.GetComponent<movement>();
            if (movement != null)
            {
                 ParticleSystem ps =Instantiate(particleSys,transform.position,transform.rotation);
                 ParticleSystem.MainModule psmain = ps.main;
                psmain.startColor = Color.white;
                movement.TakeDamage(playerDamage);
            }
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "shield")
        {
            float currentXVelocity = Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = 0;
            Debug.Log(rb.velocity);
            rb.AddForce(new Vector3(currentXVelocity,0,0)*speed);
            Debug.Log(-currentXVelocity);
            
            col.gameObject.GetComponent<Animator>().SetTrigger("willFlash");

        }
    }

}
