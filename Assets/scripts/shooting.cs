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


    private GameObject spawnerPoint;
    private spawner spawnerScipt;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
        Cam = cam.GetComponent<Camera>();
        kills = 0;
        scoreGameObject = GameObject.Find("score"); // finds the GameObject score and says that it should be the same as the string scoreGameObject
        scoreText = scoreGameObject.GetComponent<TMPro.TMP_Text>(); // now it says that it should use the text writing box TMP
        
        spawnerScipt = GameObject.Find("enemy spawner").GetComponent<spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                ray = Cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag.Equals("NPC"))
                    {
                        kills++;
                        Destroy(hit.collider.gameObject);
                        Debug.Log("you will burn");
                        spawnerScipt.spawnEnemy();
                        spawnerScipt.spawnEnemy();
                    }

                }
            }
            countdown = 0.2f;
        }
        else
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }
    
    }
    private void LateUpdate() // calling a private void called lateupdate
    {
        scoreText.text = "Kills: "+ kills.ToString();// making the text display
    }
}
