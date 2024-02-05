using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemycount;

    // Start is called before the first frame update
    void Start()
    {
       
        for(int i = 0;i <  enemycount; i++)
        {
            spawnEnemy();
        }
        if (Input.GetKey(KeyCode.P)) 
        {
            spawnEnemy();
        }


    }

    public void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-10f,10f),transform.position.y, Random.Range(-10f,10f)), Quaternion.identity);

    }
}
