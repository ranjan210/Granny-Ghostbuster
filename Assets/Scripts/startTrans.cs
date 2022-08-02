using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTrans : MonoBehaviour
{
    transition transition;
    float coachWidth;
    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("transition").GetComponent<transition>();
        coachWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

    } 

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.gameObject.tag=="Player"){
            float xpos = transform.position.x+coachWidth*20;
            transition.transitionSpawn(xpos);
            gameObject.GetComponent<startTrans>().enabled = false;
        }
    }
}
