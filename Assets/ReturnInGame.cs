using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnInGame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
