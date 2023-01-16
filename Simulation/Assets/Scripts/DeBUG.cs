using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//import UnityEngine.SceneManagement;

public class DeBUG : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

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


}
