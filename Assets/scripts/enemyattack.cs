using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyattack : MonoBehaviour
{
    private Transform player;
    private float attackRange = 30f;
    private Renderer rend;
    public float HP = 100f;
    public float killrange = 0.1f;
    public float countdown = 0f;


    private EnemyMovementScript enemyMovement;
    private bool foundplayer;

    public Renderer ren;
    public Material defaultMaterial;
    public Material allertMaterial;


    // Start is called before the first frame update
    void Start()
    {
   
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovementScript>();
        ren = GetComponent<Renderer>();
        



    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            
            ren.sharedMaterial = allertMaterial; // change material
            enemyMovement.badGuy.SetDestination(player.position);// set destination to player position
            foundplayer = true; // enable bool for chasing
            
             
            
          
        }
        else if (foundplayer)
        {
            ren.sharedMaterial = defaultMaterial; // set material back
            enemyMovement.newLocation(); // call new locatinon function
            foundplayer = false; // set bool back to false
        }
    }
}
