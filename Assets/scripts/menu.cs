using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("2Controls");
    }
    public void Menu()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("homescreen");
        }
        
    }
}