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

    // Update is called once per frame
   
}
