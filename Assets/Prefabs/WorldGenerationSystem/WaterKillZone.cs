using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") GameMode.Instance.PlayerDeath();
    }
}
