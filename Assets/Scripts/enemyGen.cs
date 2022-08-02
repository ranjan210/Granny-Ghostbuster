using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGen : MonoBehaviour
{


    // spawnDist defines the minimum dist under which a trigger is spawned
    // triggerDist defines the dist between each trigger spawn

    Vector3 spawnPos;
    public GameObject enemyTrigger;
    public Transform triggerSpawn;
    bool spawnTime = false;
    public float spawnDist;

    GameObject player;
    public float triggerDist;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setSpawn(); 
    }

    void Update()
    {
        if(player==null){
            return;
        }
        if(spawnTime){
            Instantiate(enemyTrigger,spawnPos,triggerSpawn.rotation);
            spawnPos.x += triggerDist;
            spawnTime = false;
        }

        if(Vector3.Distance(player.transform.position,spawnPos)<=spawnDist){
            spawnTime= true;
        }
    }

    void setSpawn(){
        Vector3 triggerY = triggerSpawn.position;
        spawnPos = new Vector3 (triggerY.x+triggerDist,triggerY.y,triggerY.z);
    }

   
}
