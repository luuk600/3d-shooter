using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grenade : MonoBehaviour
{
    bool hasExploded = false;
    public GameObject explosionEffect;

    private float countdown = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;  
        if (countdown<=0 && hasExploded == false)
        {
            Explode();
            hasExploded = true;
            
        }
    }


    private void Explode()
    {
        var bomb = Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(bomb);























        Destroy(gameObject);
        ExampleCoroutine();
        
     
        Destroy(bomb);
        Debug.Log("destroy");
        

    }
    IEnumerator ExampleCoroutine() // the coroutine tine for pause
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time); // signaling that the coroutine has started

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5); //making the game wait for 3 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // looking for the scene so it can reload it

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time); // signaling that the coroutine has ended 
    }

}
