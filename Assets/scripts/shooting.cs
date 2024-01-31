using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float kills;
    public GameObject cam;
    public Camera Cam;
    private GameObject scoreGameObject;
    private TMPro.TMP_Text scoreText;
    private RaycastHit hit;
    private Ray ray;
    public GameObject enemyPrefab;
    public float countdown = 0.2f;
    public grenade grenadeScript;

    private GameObject spawnerPoint;
    private spawner spawnerScript;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
        Cam = cam.GetComponent<Camera>();
        
        kills = 0;
        scoreGameObject = GameObject.Find("score"); // finds the GameObject score and says that it should be the same as the string scoreGameObject
        scoreText = scoreGameObject.GetComponent<TMPro.TMP_Text>(); // now it says that it should use the text writing box TMP

        spawnerScript = GameObject.Find("enemy spawner").GetComponent<spawner>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("itl work");
                //if (hit.collider.gameObject.Find(" "))
                //    {

                //}
                //if (hit.collider.tag.Equals("NPC"))
                //{
                //    kills++;
                //    Destroy(hit.collider.gameObject);
                //    //Debug.Log("you will burn");
                //    spawnerScipt.spawnEnemy();
                //    spawnerScipt.spawnEnemy();

                //}
                // Check if there's a collision and the collider has a tag "NPC"
                if (hit.collider != null && hit.collider.CompareTag("NPC"))
                {
                    // Increment kill count
                    kills++;

                    // Destroy the NPC GameObject
                    Destroy(hit.collider.gameObject);

                    // Check if the spawnerScript is assigned
                    if (spawnerScript != null)
                    {
                        // Spawn two new enemies using the spawnerScript
                        spawnerScript.spawnEnemy();
                        spawnerScript.spawnEnemy();
                    }
                    else
                    {
                        // If spawnerScript is not assigned, log a warning
                        Debug.LogWarning("Spawner script is not assigned!");
                    }
                }
                else
                {
                    // If no collision with an NPC, log a message
                    Debug.Log("No collision with NPC detected!");
                }

            }
        }

    }

    
    private void LateUpdate() // calling a private void called lateupdate
    {
        
        scoreText.text = "Kills: "+ kills.ToString();// making the text display
        //Debug.Log(kills);
    }
}
