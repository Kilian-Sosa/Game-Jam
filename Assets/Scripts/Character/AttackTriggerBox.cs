using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerBox : MonoBehaviour
{
    private List<GameObject> Enemies = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Remove(collision.gameObject);
        }
    }

    public List<GameObject> GetEnemies()
    {
        List<GameObject> enemies = new List<GameObject>(Enemies);
        foreach (GameObject enemy in Enemies)
        {
            if(enemy == null)
            {
                Enemies.Remove(enemy);
            }
        }
        return Enemies;
    }
}
