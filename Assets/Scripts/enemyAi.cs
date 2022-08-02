using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    bool touchingPlayer;
    Transform player;
    public float speed;
    Rigidbody2D rb;
    float nextFollowTime = 0f;
    public float coolDown;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        touchingPlayer = false;

    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (GameObject.FindGameObjectWithTag("Player") != null && !touchingPlayer)
        {
            Vector2 dir = player.position - transform.position;
            rb.velocity = dir.normalized * speed;
        }
        if (Time.time >= nextFollowTime && touchingPlayer == true)
        {
            switchFollow();
        }
    }

    public void switchFollow()
    {

        touchingPlayer = !touchingPlayer;
        nextFollowTime = Time.time + coolDown;
        Debug.Log(touchingPlayer + ":" + nextFollowTime);
    }


}
