using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour
{
    public GameObject[] fog;
    public float interval;
    float timer;
    int currentFog;

    void Start()
    {
        timer = interval;
        currentFog = Random.Range(0, 3);
        GameObject fogObj = Instantiate(fog[currentFog], transform.position, transform.rotation);
        currentFog++;
        if (currentFog > 2)
        {
            currentFog = 0;
        }
        fogObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GameObject fogObj = Instantiate(fog[currentFog], transform.position, transform.rotation);
            currentFog = Random.Range(0,3);
            if (currentFog > 2)
            {
                currentFog = 0;
            }
            fogObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            timer = interval;
        }
    }
}
