using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
            
        if (instance == null) {
            instance = this;
        } else {
            DestroyObject(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
