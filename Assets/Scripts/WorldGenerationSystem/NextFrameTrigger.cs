using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFrameTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTriggered && collision.CompareTag("Player"))
        {
            hasTriggered = true;
            GameMode.Instance.GenerateNextLevelFrame();
        }
    }
}
