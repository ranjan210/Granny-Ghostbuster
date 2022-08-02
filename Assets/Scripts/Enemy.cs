using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float force;
    Rigidbody2D rb;
    Animator anim;
    GameManager scoreHandler;
    public GameObject death_particle;
    AudioSource audioSrc;
    public AudioClip ghost_hurt;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        scoreHandler = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSrc.PlayOneShot(ghost_hurt);
        anim.SetTrigger("isHurt");
        if (health <= 0)
        {
            gameObject.GetComponent<enemyAi>().switchFollow();
        }
    }

    void Die()
    {

        if (health <= 0)
        {
            GameObject particle1 = Instantiate(death_particle, transform.position, Quaternion.Euler(0, 0, 35));
            GameObject particle2 = Instantiate(death_particle, transform.position, Quaternion.Euler(0, 0, 150));
            GameObject particle3 = Instantiate(death_particle, transform.position, Quaternion.Euler(0, 0, 210));
            GameObject particle4 = Instantiate(death_particle, transform.position, Quaternion.Euler(0, 0, 345));

            Destroy(gameObject);
            scoreHandler.updateScore(50);
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            gameObject.GetComponent<enemyAi>().switchFollow();
            col.collider.gameObject.GetComponent<movement>().TakeDamage(20);
        }
    }

    /* void OnCollisionExit2D(Collision2D col)
     {
         gameObject.GetComponent<enemyAi>().stopFollow();
     }*/

    public void PushBack(Vector3 dir)
    {
        Debug.Log(dir * force);
        gameObject.GetComponent<enemyAi>().switchFollow();
        rb.AddForce(-dir * force);
    }
}
