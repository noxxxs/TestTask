using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name != "SecondScene")
            {
                Debug.Log("+");
                SceneManager.LoadScene(1);
            } else
            {
                SceneManager.LoadScene(0);
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
