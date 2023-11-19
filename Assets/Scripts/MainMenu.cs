using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelName;
    
    public bool canStart = true;

    public void SetCanStart( bool b )
    {
        canStart = b;
    }
    
    void Update()
    {
        if ( canStart )
        {
            if ( Input.anyKey && !Input.GetMouseButton(0) )
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
