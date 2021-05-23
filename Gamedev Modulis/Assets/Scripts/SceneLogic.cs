using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLogic : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Update() 
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Restart();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    // Update is called once per frame
   
}
