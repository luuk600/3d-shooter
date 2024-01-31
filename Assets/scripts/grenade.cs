using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grenade : MonoBehaviour
{
    private int kill;
    private int gkill;
    private bool hasExploded = false;
    public GameObject explosionEffect;
    public spawner spawnerScript;
    public float radius = 5f;
    private float force = 7f;
    private float cjountdown = 3f;
    private GameObject bomb;
    public shooting shootingScript;
    private TMPro.TMP_Text gkills;


    void Start()
    {
        shootingScript = GetComponent<shooting>(); // searching the shooting script
        spawnerScript = GetComponent<spawner>(); // searching the spawner script
        gkills = GameObject.Find("gkills").GetComponent<TMPro.TMP_Text>(); // searching the 
     

       

    }

    // Update is called once per frame
    void Update()
    {
        
        cjountdown -= Time.deltaTime;  // timer
        if (cjountdown<=0 && hasExploded == false)
        {
            
            Explode();// calling explode
            hasExploded = true;  
            
        }
        
    }


    private void Explode()
    {

        bomb = Instantiate(explosionEffect, transform.position, transform.rotation);// explosie effect in positie van granaat
        Instantiate(bomb);
        

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); // looking for the colliders in the radius
        foreach (Collider nearbyObject in colliders) // for each nearby collider do this
        {
            kill = kill+1;
            //Debug.Log(gkill);
            //shootingScript.kills += kil;
            Rigidbody rb = nearbyObject.gameObject.GetComponent<Rigidbody>(); // ridgid body in radius = rb = ridgidbody seeks the rigitbodys
            if (rb != null ) // if rb isn't 0 then
            {
                
                rb.AddExplosionForce(force, transform.position, radius);// pushes the enemy's away


                Destroy(nearbyObject.gameObject);// destroys nearby gameobjet or enemy
                //if (Destroy(nearbyObject.gameObject) = true)
                //{
                //    kil++;
                //}

            }


        }
        
        ExampleCoroutine(); // calling example coroutine
        
    }
   
    public void ExampleCoroutine() // the coroutine tine for pause
    {
        //explosion.Play();
        //yield on a new YieldInstruction that waits for 5 seconds.
        
        Destroy(bomb);// destroys the bomb
        //Debug.Log("destroy");
        Destroy(gameObject); // destroys the dynamite
        //shootingScript.kills += kil;
        
        
    }

    private void LateUpdate() // last update of the frame
    {
        
        Debug.Log(gkill); // debuging gkill in the code
        gkills.text = "Grenade Kills: " + kill.ToString(); // displaying the score

    }
}
