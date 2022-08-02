using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour

{
    public float speed=1f;

    Transform player;
    Vector3 pos1;
    Vector3 pos2;
    public float amp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pos1 = transform.position;
        pos2 = new Vector3(transform.position.x,transform.position.y+amp,transform.position.z);

    }

    void Update()
    {
        
        transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        }
    }

}