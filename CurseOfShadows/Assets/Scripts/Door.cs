using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    // public variabls editable in unity
    public string targetScene = "";

    //Condition
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //CONDITION
        if (collision.CompareTag("Player"))
        {
            ChangeScene();
        }
       
    }

    //Action
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }

}
