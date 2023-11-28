using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyattack : MonoBehaviour
{
    private Transform player;
    private float attackRange = 30f;
    private Renderer rend;
    
    private GameObject Ren;

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
        player = GameObject.FindGameObjectWithTag("player").transform;
        enemyMovement = GetComponent<EnemyMovementScript>();
        rend = GetComponent<Renderer>();



        Awake();
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.position) <= attackRange)
        {
            rend.sharedMaterial = allertMaterial; // change material
            enemyMovement.badGuy.SetDestination(player.position);// set destination to player position
            foundplayer = true; // enable bool for chasing
        }
        else if (foundplayer) 
        {
            rend.sharedMaterial = defaultMaterial; // set material back
            enemyMovement.newLocation(); // call new locatinon function
            foundplayer = false; // set bool back to false
        }
    }
   
}
