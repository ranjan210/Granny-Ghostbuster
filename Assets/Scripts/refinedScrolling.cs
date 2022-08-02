using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refinedScrolling : MonoBehaviour
{
    float spriteWidth;
    float camWidth;
    float startPos;
    float initOffset;
    float finalOffset;
    float initPos;
    public int spriteCount;
    Rigidbody2D rb;
    public float scrollSpeed = 16;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        camWidth = height * cam.aspect;

        startPos = Camera.main.transform.position.x - (camWidth / 2);
        initOffset = Mathf.Abs(camWidth - (3 * spriteWidth));
        finalOffset = startPos - initOffset - spriteWidth ;
        finalOffset = Mathf.Abs(finalOffset - cam.transform.position.x);
        rb.velocity = Vector2.left * scrollSpeed;

    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - (spriteWidth/2) - Camera.main.transform.position.x) >= finalOffset)
        {
            transform.position = new Vector3(transform.position.x + (spriteCount * spriteWidth), transform.position.y, transform.position.z);
        }
    }
}
