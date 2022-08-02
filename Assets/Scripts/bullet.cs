using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bullSpeed;
    public int damage = 50;
    Rigidbody2D rb;
    public float thresold;
    public ParticleSystem bulletPs;
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bullSpeed;
    }

    void Update()
    {
        if (Mathf.Abs(Camera.main.transform.position.x - transform.position.x) > thresold)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ghosts")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Instantiate(bulletPs, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
