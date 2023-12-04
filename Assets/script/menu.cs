using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("TheGame");
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void quit()
    {
        Application.Quit();
    }
}