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
    private float force = 700f;
    private float cjountdown = 3f;
    private GameObject bomb;
    public shooting shootingScript;
    private TMPro.TMP_Text gkills;


    void Start()
    {
        shootingScript = GetComponent<shooting>();
        spawnerScript = GetComponent<spawner>();
        gkills = GameObject.Find("gkills").GetComponent<TMPro.TMP_Text>();
     

       

    }

    // Update is called once per frame
    void Update()
    {
        
        cjountdown -= Time.deltaTime;  
        if (cjountdown<=0 && hasExploded == false)
        {
            
            Explode();
            hasExploded = true;
            
        }
        
    }


    private void Explode()
    {

        bomb = Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(bomb);
        

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); // looking for the colliders in the radius
        foreach (Collider nearbyObject in colliders) // for each nearby collider do this
        {
            kill = kill+1;
            //Debug.Log(gkill);
            //shootingScript.kills += kil;
            Rigidbody rb = nearbyObject.gameObject.GetComponent<Rigidbody>();
            if (rb != null )
            {
                
                rb.AddExplosionForce(force, transform.position, radius);


                Destroy(nearbyObject.gameObject);
                //if (Destroy(nearbyObject.gameObject) = true)
                //{
                //    kil++;
                //}

            }


        }
        
        ExampleCoroutine();
        
    }
   
    public void ExampleCoroutine() // the coroutine tine for pause
    {
        //explosion.Play();
        //yield on a new YieldInstruction that waits for 5 seconds.
        
        Destroy(bomb);
        //Debug.Log("destroy");
        Destroy(gameObject);
        //shootingScript.kills += kil;
        
        
    }

    private void LateUpdate()
    {
        
        Debug.Log(gkill);
        gkills.text = "Grenade Kills: " + kill.ToString();

    }
}
