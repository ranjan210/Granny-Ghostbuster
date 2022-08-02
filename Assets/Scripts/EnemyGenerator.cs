using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public int enemyRate;
    public int enemyQuan;
    public float speedMultiplier;
    float screenWidth;
    int randomIndex;
    int randomGhostIndex;
    int enemyNo = 0;
    int randomMultipleIndex;
    private IEnumerator coroutine;
    void Start()
    {
        screenWidth = (Camera.main.orthographicSize * 2.0f) * (Screen.width / Screen.height);
        randomIndex = Random.Range(0, 2);
        randomMultipleIndex = Random.Range(0, 2);
        if (randomMultipleIndex == 1)
        {
            enemyQuan += 2;
        }
        if (randomIndex == 1)
        {
            randomGhostIndex = Random.Range(0, enemyQuan + 1);
        }
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            coroutine = GenerateEnemies(1 / enemyRate);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator GenerateEnemies(float waitTime)
    {
        while (enemyNo != enemyQuan)
        {
            enemyNo += 1;
            Vector2 pos = new Vector3(transform.position.x + screenWidth, transform.position.y + 2, 0);
            GameObject ghost = Instantiate(enemy, pos, transform.rotation);
            if (enemyNo == randomGhostIndex)
            {
                ghost.GetComponent<enemyAi>().speed *= speedMultiplier;
            }
            yield return new WaitForSeconds(waitTime);
        }

        if (enemyNo == enemyQuan)
        {
            StopCoroutine(coroutine);
            if (gameObject.tag != "ExceptionTrigger")
            {
                Destroy(gameObject);
            }
        }

    }
}
