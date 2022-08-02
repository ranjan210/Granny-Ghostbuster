using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbackground : MonoBehaviour {
    public int scrollSpeed ;

    Rigidbody2D rb ;
    float width;
    Vector3 startPos;
    Transform cameraTransform;

    Vector3 lastCameraPosition;
    float initOffest;
    public float spriteCount;
    public float index;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        cameraTransform = Camera.main.transform;
         Camera cam = Camera.main;
        initOffest = transform.position.x - cameraTransform.position.x;
        rb.velocity = Vector2.left*scrollSpeed;
        startPos = transform.position;
        
    }
    void Update(){
    
        float distTravelled = transform.position.x-startPos.x;
        if(Mathf.Abs(cameraTransform.position.x-transform.position.x)>=width*(spriteCount-1)){
            transform.position = new Vector3(transform.position.x+width*spriteCount,transform.position.y,transform.position.z);
        }

        startPos = transform.position;
    }

    
}