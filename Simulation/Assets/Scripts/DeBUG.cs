using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//import UnityEngine.SceneManagement;

public class DeBUG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
