using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//import UnityEngine.SceneManagement;

public class DeBUG : MonoBehaviour
{
    public void deBugActive()
    {
        Debug.Log("Debug aktif");
    }
    public  void deBuDeactive()
    {
        Debug.Log("Debug pasif");
    }
    public void reStartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void ExitGame()
    {
        Application.Quit();
    }

}
