//Coded by Brandon 22/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutskirtsTo_Town : MonoBehaviour
{
    public string targetScene = "";

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
