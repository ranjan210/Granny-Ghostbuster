using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_manager : MonoBehaviour
{

    GameObject player;
    public float thresold;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null){
            if((Vector3.Distance(player.transform.position,transform.position)>thresold)&&transform.position.x<player.transform.position.x){
            Destroy(gameObject);
        }
        }
        
    }

    
}
