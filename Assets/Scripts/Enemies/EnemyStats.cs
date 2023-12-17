using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private int experience = 20;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameMode.Instance.AddExperience(experience);
            transform.position = new Vector3(10000, 10000, 10000);
        }
    }

}
