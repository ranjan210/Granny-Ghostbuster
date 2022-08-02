using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPosition : MonoBehaviour

{

    public Transform player;
    public float cameraLength;
    public float cameraDisp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > cameraLength)
            {
                Vector3 targetDist = transform.position;
                targetDist.x += cameraDisp;
                transform.position = targetDist;
            }
        }

    }
}
