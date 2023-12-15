using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemycount;
    private shooting shooting;
    private float Countdown = 2;
    // Start is called before the first frame update
    void Start()
    {
       
        for(int i = 0;i <  enemycount; i++)
        {
            spawnEnemy();
        }
   
       
    }
    private void Update()
    {
        Countdown -= Time.deltaTime;
        if(Countdown <= 0) 
        {
            spawnEnemy();
            Countdown = 2;
        }
        
    }
    public void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-100f,100f),transform.position.y, Random.Range(-100f,100f)), Quaternion.identity);

    }
}
