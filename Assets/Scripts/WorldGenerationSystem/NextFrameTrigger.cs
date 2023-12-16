using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFrameTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        
        if(!hasTriggered && collision.CompareTag("Player"))
        {
            Debug.Log("Is Player");
            hasTriggered = true;
            GameMode.Instance.GenerateNextLevelFrame();
        }
    }
}
