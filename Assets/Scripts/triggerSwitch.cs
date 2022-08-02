using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSwitch : MonoBehaviour
{
    transition transition;
    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("transition").GetComponent<transition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            transition.switchBg();
        }
    }
}
