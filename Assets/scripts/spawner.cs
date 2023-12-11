using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemycount;
    private shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
       
        for(int i = 0;i <  enemycount; i++)
        {
            spawnEnemy();
        }
   
       
    }

    public void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-30f,30f),transform.position.y, Random.Range(-30f,30f)), Quaternion.identity);

    }
}
