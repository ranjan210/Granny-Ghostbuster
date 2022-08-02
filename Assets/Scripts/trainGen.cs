using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TrainSet
{
    [SerializeField]
    public GameObject coach;
    public GameObject engine;
}

public class trainGen : MonoBehaviour
{
    public TrainSet[] trainSets;
    int currentTrain = 0;
    Vector3 spawnPos;
    public GameObject trainCoach;
    public GameObject trainEngine;
    bool spawnTime = false;
    bool transitionTime = false;
    GameObject player;
    float spawnDist;
    float coachWidth;
    public Transform trainSpawn;
    public Transform trainEngineSpawn;
    GameObject trainParent;
    public float levelDist;
    transition transition;
    public GameObject startTrans;
    void Awake()
    {
        setSpawn();

    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trainParent = GameObject.FindGameObjectWithTag("mainTrain");
        coachWidth = trainCoach.GetComponent<SpriteRenderer>().bounds.size.x;
        spawnDist = coachWidth * 6;
        transition = GameObject.FindGameObjectWithTag("transition").GetComponent<transition>();

    }

    void Update()
    {
        if(player==null){
            return;
        }
        
        if (spawnTime && (!transitionTime))
        {
            GameObject newTrain = Instantiate(trainCoach, spawnPos, transform.rotation);
            newTrain.transform.parent = trainParent.transform;
            spawnPos.x += coachWidth;
            spawnTime = false;
        }
      
        if (Vector2.Distance(player.transform.position, spawnPos) <= spawnDist)

        {
            spawnTime = true;
        }
        if (Input.GetKeyDown("a"))
        {
            transitionTime = true;
        }
        if (transitionTime)
        {
            transitionTime = false;

            Transition();

        }

    }

    void setSpawn()
    {
        coachWidth = trainCoach.GetComponent<SpriteRenderer>().bounds.size.x;
        Vector3 trainY = trainSpawn.position;
        spawnPos = new Vector3(trainY.x + coachWidth, trainY.y, trainY.z);

    }

    void Transition()
    {
        GameObject endTrain = Instantiate(trainEngine, spawnPos, transform.rotation);
        endTrain.transform.parent = trainParent.transform;
        spawnPos.x += levelDist;
        currentTrain++;
        if (currentTrain > 1)
        {
            currentTrain = 0;
        }
        trainEngine = trainSets[currentTrain].engine;
        trainCoach = trainSets[currentTrain].coach;

        Quaternion rot = Quaternion.Euler(0, 180, 0);
        GameObject newTrain = Instantiate(trainEngine, spawnPos, rot);
        spawnPos.x += coachWidth;
        newTrain.transform.parent = trainParent.transform;
        for (int i = 0; i < 4; i++)
        {
            GameObject newCoach = Instantiate(trainCoach, spawnPos, transform.rotation);
            newCoach.transform.parent = trainParent.transform;
            spawnPos.x += coachWidth;
            if(i==1){
                newCoach.AddComponent<startTrans>();
            }
        }
    
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(spawnPos, "spawnPos", true);

    }

}
