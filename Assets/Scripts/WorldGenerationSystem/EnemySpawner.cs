using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Level1EnemyClass;
    [SerializeField] private GameObject Level2EnemyClass;
    [SerializeField] private GameObject Level3EnemyClass;

    private void Start()
    {
        GameObject EnemyToSpawn = SelectEnemy();
        if(EnemyToSpawn != null)
        {
            Instantiate(SelectEnemy(), transform.position, transform.rotation);
        }
        Destroy(gameObject, 0.5f);
    }

    private GameObject SelectEnemy()
    {
        switch (GameMode.Instance.getPlayerLevel())
        {
            case 0: return Level1EnemyClass;
            case 1: return Level2EnemyClass;
            case 2: return Level3EnemyClass;
            default: return Level3EnemyClass;
        }
    }
}
