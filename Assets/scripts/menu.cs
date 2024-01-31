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
        SceneManager.LoadScene("homescreen");
    }
    public void winscreen()
    {
        SceneManager.LoadScene("2Controls");
    }
}
