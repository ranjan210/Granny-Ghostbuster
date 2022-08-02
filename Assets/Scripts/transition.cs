using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackgroundSet
{
    public Sprite background;
    public Sprite foreground;

}
public class transition : MonoBehaviour
{
    public Vector3 caveSpeed;
    int currentIndex = 0;
    public GameObject transitionObj;
    public BackgroundSet[] backgroundSets;
    GameObject[] bGround;
    GameObject[] fGround;
    void Start()
    {
        bGround = GameObject.FindGameObjectsWithTag("background");
        fGround = GameObject.FindGameObjectsWithTag("ground");

    }

    void Update()
    {

    }


    public void transitionSpawn(float xPos)
    {
        Vector3 pos = new Vector3 (xPos,transform.position.y,transform.position.z);
        GameObject obj = Instantiate(transitionObj, pos, transform.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = caveSpeed;
    }

    public void switchBg()
    {
        currentIndex++;
        if (currentIndex > 1)
        {
            currentIndex = 0;
        }
        foreach (var item in bGround)
        {
            item.GetComponent<SpriteRenderer>().sprite = backgroundSets[currentIndex].background;
        }
        foreach (var item in fGround)
        {
            item.GetComponent<SpriteRenderer>().sprite = backgroundSets[currentIndex].foreground;
        }

    }
}
