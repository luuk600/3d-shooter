using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float hP = 100f;
    public float countdown = 0;
    private Transform player;
    private GameObject enemy;
    private GameObject scoreGameObject;
    private TMPro.TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.Find("enemy");
        scoreGameObject = GameObject.Find("hp"); // finds the GameObject score and says that it should be the same as the string scoreGameObject
        scoreText = scoreGameObject.GetComponent<TMPro.TMP_Text>(); // now it says that it should use the text writing box TMP


    }

    // Update is called once per frame
    void Update()
    {

      
    }
    
private void OnCollisionStay(Collision collision)
{
    if (collision.gameObject.CompareTag("NPC"))
        {
            if (countdown == 0)
            {
                hP--;

                countdown = 0;
                if (hP <= 0)
                {
                    Debug.Log("you are defeated");
                    ExampleCoroutine();
                    SceneManager.LoadScene("defeated");
                }
            }
            else
            {
                countdown = 0;
                Debug.Log("countdown = " + countdown);
            }
        }
    }
    private void LateUpdate() // calling a private void called lateupdate
    {
        scoreText.text = "HP: " + hP.ToString();// making the text display
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
