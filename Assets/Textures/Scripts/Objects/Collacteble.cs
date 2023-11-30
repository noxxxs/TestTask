using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collacteble : MonoBehaviour
{
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) 
        {
            GameObject.Destroy(this.gameObject);
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
