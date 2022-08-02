using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundObjGenerator : MonoBehaviour
{

    public float minTime;
    public float maxTime;
    public int currentProp = 0;
    public Sprite[] props;
    public GameObject emptyBluePrint;
    float timer;
    public float speed;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (timer <= 0)
        {
            currentProp = Random.Range(0, 3);
            GameObject obj = Instantiate(emptyBluePrint, transform.position, transform.rotation);
            obj.GetComponent<SpriteRenderer>().sprite = props[currentProp];
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            timer = Random.Range(minTime, maxTime);
        }
        timer -= Time.deltaTime;
    }
}
